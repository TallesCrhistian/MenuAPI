using MenuAPI.Identity.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Enterprise;
using MenuAPI.Shared.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IIdentityServices _identityService;

        public UserController(IIdentityServices identityService) =>
            _identityService = identityService;

        /// <summary>
        /// Cadastro de usuário.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="userCreateViewModel">Dados de cadastro do usuário</param>
        /// <returns></returns>
        /// <response code="200">Usuário criado com sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar(UserCreateViewModel userCreateViewModel)
        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = await _identityService.CreateUser(userCreateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = await _iUserServices.Read(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Update Enterprise.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="enterpriseUpdateViewModel">Object for Update a Enterprise.</param>
        /// <returns></returns>
        /// <response code="200">Enterprise Update successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Enterprise not found.</response>
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromHeader] Guid id, [FromBody] UserUpdateViewModel userUpdateViewModel)

        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = await _iUserServices.Update(userUpdateViewModel, id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Delete Enterprise.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Variable for Delete a Enterprise.</param>
        /// <returns></returns>
        /// <response code="200">Enterprise Update successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Enterprise not found.</response>
        [ProducesResponseType(typeof(EnterpriseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = await _iUserServices.Delete(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
    }
}
