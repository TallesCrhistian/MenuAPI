using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Enterprise;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseServices _iEnterpriseServices;

        public EnterpriseController(IEnterpriseServices iEnterpriseServices)
        {
            _iEnterpriseServices = iEnterpriseServices;
        }


        /// <summary>
        /// Create Enterprise.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="enterpriseCreateViewModel">Object for create a new Enterprise.</param>
        /// <returns></returns>
        /// <response code="200">Enterprise create successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        [ProducesResponseType(typeof(EnterpriseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnterpriseCreateViewModel enterpriseCreateViewModel)

        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = await _iEnterpriseServices.Create(enterpriseCreateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        /// <summary>
        /// Read Enterprise.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="id">Variable for Read a Enterprise.</param>
        /// <returns></returns>
        /// <response code="200">Enterprise read successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        /// <response code="404">Enterprise not found.</response>
        [ProducesResponseType(typeof(EnterpriseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = await _iEnterpriseServices.Read(id);

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
        [ProducesResponseType(typeof(EnterpriseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromHeader] Guid id, [FromBody] EnterpriseUpdateViewModel enterpriseUpdateViewModel)

        {
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = await _iEnterpriseServices.Update(enterpriseUpdateViewModel, id);

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
            ServiceResponseDTO<EnterpriseViewModel> serviceResponseDTO = await _iEnterpriseServices.Delete(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
    }
}
