using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Product;

namespace MenuAPI.Services.Interfaces
{
    public interface IProductServices
    {
        Task<ServiceResponseDTO<ProductViewModel>> Create(ProductCreateViewModel productCreateViewModel);
        Task<ServiceResponseDTO<ProductViewModel>> Delete(Guid id);
        Task<ServiceResponseDTO<ProductViewModel>> Read(Guid id);
        Task<ServiceResponseDTO<ProductViewModel>> Update(ProductUpdateViewModel productUpdateViewModel, Guid id);


    }
}