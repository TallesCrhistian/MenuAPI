using MenuAPI.Shared.DTOs;

namespace MenuAPI.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<ProductDTO> Delete(Guid id);
        Task<ProductDTO> Read(Guid id);
        Task<ProductDTO> Update(ProductDTO productDTO, Guid id);
    }
}