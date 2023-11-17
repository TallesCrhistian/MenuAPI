﻿using MenuAPI.Identity.Configuration;
using MenuAPI.Identity.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.Messages;
using MenuAPI.Shared.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace MenuAPI.Identity.Services
{
    public class IdentityServices : IIdentityServices
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWorkUnitIdentity _iWorkUnitIdentity;
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<IdentityServices> _logger;

        public IdentityServices(SignInManager<IdentityUser> signInManager,
                               UserManager<IdentityUser> userManager,
                               IOptions<JwtOptions> jwtOptions,
                               IWorkUnitIdentity workUnitIdentity,
                               ILogger<IdentityServices> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
            _iWorkUnitIdentity = workUnitIdentity;
            _logger = logger;
        }

        public async Task<ServiceResponseDTO<UserViewModel>> CreateUser(UserCreateViewModel userCreateViewModel)
        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = new ServiceResponseDTO<UserViewModel>();

            var identityUser = new IdentityUser
            {
                UserName = userCreateViewModel.Email,
                Email = userCreateViewModel.Email,
                EmailConfirmed = true,
                PasswordHash = userCreateViewModel.PasswordHash,
                PhoneNumber = userCreateViewModel.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(identityUser, userCreateViewModel.PasswordHash);

                if (result.Succeeded)
                    await _userManager.SetLockoutEnabledAsync(identityUser, false);

                UserViewModel userViewModel = new UserViewModel()
                {
                    Email = userCreateViewModel.Email,
                    Name = userCreateViewModel.UserName
                };

                serviceResponseDTO.GenericData = userViewModel;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                serviceResponseDTO.Message = CreatedMessages.User;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnitIdentity.SaveChangesAsync();
                await _iWorkUnitIdentity.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnitIdentity.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            }

            return serviceResponseDTO;
        }

        public async Task<UserLoginResponseDTO> Login(UserLoginViewModel userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            if (result.Succeeded)
                return await GerarCredenciais(userLogin.Email);

            var usuarioLoginResponse = new UserLoginResponseDTO();
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                else if (result.IsNotAllowed)
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                else if (result.RequiresTwoFactor)
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                else
                    usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
            }

            _logger.LogDebug("Login realizado com sucesso!");

            return usuarioLoginResponse;
        }

        public async Task<UserLoginResponseDTO> LoginNoPassword(string userId)
        {
            var userLoginResponse = new UserLoginResponseDTO();
            var user = await _userManager.FindByIdAsync(userId);

            if (await _userManager.IsLockedOutAsync(user))
                userLoginResponse.AdicionarErro("Essa conta está bloqueada");
            else if (!await _userManager.IsEmailConfirmedAsync(user))
                userLoginResponse.AdicionarErro("Essa conta precisa confirmar seu e-mail antes de realizar o login");

            if (userLoginResponse.Sucesso)
                return await GerarCredenciais(user.Email);

            return userLoginResponse;
        }

        private async Task<UserLoginResponseDTO> GerarCredenciais(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var accessTokenClaims = await GetClaims(user, adicionarClaimsUsuario: true);
            var refreshTokenClaims = await GetClaims(user, adicionarClaimsUsuario: false);

            var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = GenerateToken(accessTokenClaims, dataExpiracaoAccessToken);
            var refreshToken = GenerateToken(refreshTokenClaims, dataExpiracaoRefreshToken);

            return new UserLoginResponseDTO
            (
                sucesso: true,
                accessToken: accessToken,
                refreshToken: refreshToken
            );
        }

        private string GenerateToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: dataExpiracao,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private async Task<IList<Claim>> GetClaims(IdentityUser user, bool adicionarClaimsUsuario)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            if (adicionarClaimsUsuario)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(userClaims);

                foreach (var role in roles)
                    claims.Add(new Claim("role", role));
            }

            return claims;
        }
    }
}
