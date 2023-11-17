using AutoMapper;
using MenuAPI.Business.Interfaces;
using MenuAPI.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using MenuAPI.Identity.Interface;

namespace MenuAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _iUserRepository;

        public UserBusiness(IMapper mapper, IUserRepository iUserRepository)
        {
            _mapper = mapper;
            _iUserRepository = iUserRepository;
        }
               
        public async Task<UserDTO> Read(Guid id)
        {
            IdentityUser user = await _iUserRepository.Read(id.ToString());

            UserDTO userDTO = user is not null ? _mapper.Map<UserDTO>(user)
                : throw new HttpRequestException();

            return userDTO;
        }

        public async Task<UserDTO> Update(UserDTO userDTO, Guid id)
        {

            IdentityUser user = await _iUserRepository.Read(id.ToString()); ;

            if (user is not null)
            {
                user = _mapper.Map<IdentityUser>(userDTO);

                                user.Id = id.ToString() ;

                user = await _iUserRepository.Update(user);

                userDTO = user is not null ? _mapper.Map<UserDTO>(user)
                    : throw new HttpRequestException();

                return userDTO;
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<UserDTO> Delete(Guid id)
        {
            IdentityUser user = await _iUserRepository.Read(id.ToString());

            if (user is not null)
            {
                await _iUserRepository.Delete(id.ToString());
            }
            else
            {
                throw new HttpRequestException();
            }

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}
