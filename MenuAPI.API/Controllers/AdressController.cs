using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Adress;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressServices _iAdressServices;

        public AdressController(IAdressServices iAdressServices)
        {
            _iAdressServices = iAdressServices;
        }


        /// <summary>
        /// Create adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="adressCreateViewModel">Object for create a new Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress create successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        [ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdressCreateViewModel adressCreateViewModel)

        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = await _iAdressServices.Create(adressCreateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Read adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Variable for Read a Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress read successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Adress not found.</response>
        [ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = await _iAdressServices.Read(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Update adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="adressUpdateViewModel">Object for Update a Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress Update successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Adress not found.</response>
        [ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromHeader] Guid id, [FromBody] AdressUpdateViewModel adressUpdateViewModel)

        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = await _iAdressServices.Update(adressUpdateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Delete adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Variable for Delete a Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress Update successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Adress not found.</response>
        [ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            ServiceResponseDTO<AdressViewModel> serviceResponseDTO = await _iAdressServices.Delete(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// List Adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="adressCreateViewModel">Object for List a Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress List successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Adress not found.</response>
        [ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> List(AdressListViewModel adressListViewModel)

        {
            ServiceResponseDTO<List<AdressViewModel>> serviceResponseDTO = await _iAdressServices.List(adressListViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

    }
}
