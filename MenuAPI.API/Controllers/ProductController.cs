using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Enterprise;
using MenuAPI.Shared.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace MenuAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _iProductServices;

        public ProductController(IProductServices iProductServices)
        {
            _iProductServices = iProductServices;
        }


        /// <summary>
        /// Create Enterprise.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="productCreateViewModel">Object for create a new Enterprise.</param>
        /// <returns></returns>
        /// <response code="200">Enterprise create successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateViewModel productCreateViewModel)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Create(productCreateViewModel);

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
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Read(id);

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
        public async Task<IActionResult> Update([FromHeader] Guid id, [FromBody] ProductUpdateViewModel productUpdateViewModel)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Update(productUpdateViewModel, id);

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
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Delete(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }
    }
}
