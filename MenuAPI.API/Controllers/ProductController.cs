using MenuAPI.Services;
using MenuAPI.Services.Interfaces;
using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Adress;
using MenuAPI.Shared.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
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
        /// Create adress.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="adressCreateViewModel">Object for create a new Adress.</param>
        /// <returns></returns>
        /// <response code="200">Adress create successfully</response>
        /// <response code="400">Return errors of validation</response>
        /// <response code="500">Return errors case occur</response>
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateViewModel productCreateViewModel)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Create(productCreateViewModel);

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
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Delete(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        ///// <summary>
        ///// List Adress.
        ///// </summary>
        ///// <remarks>
        ///// </remarks>
        ///// <param name="adressCreateViewModel">Object for List a Adress.</param>
        ///// <returns></returns>
        ///// <response code="200">Adress List successfully</response>
        ///// <response code="400">Return errors of validation</response>
        ///// <response code="500">Return errors case occur</response>
        ///// <response code="404">Adress not found.</response>
        //[ProducesResponseType(typeof(AdressCreateViewModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        //[HttpPut]
        //public async Task<IActionResult> List(AdressListViewModel adressListViewModel)

        //{
        //    ServiceResponseDTO<List<AdressViewModel>> serviceResponseDTO = await _iAdressServices.List(adressListViewModel);

        //    return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        //}

    }
}
