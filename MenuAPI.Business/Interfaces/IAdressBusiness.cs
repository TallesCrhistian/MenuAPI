using MenuAPI.Shared.DTOs;

namespace MenuAPI.Business.Interfaces
{
    public interface IAdressBusiness
    {
        Task<AdressDTO> Create(AdressDTO adressDTO);
        Task<AdressDTO> Delete(Guid id);
        Task<AdressDTO> Read(Guid id);
        Task<AdressDTO> Update(AdressDTO adressDTO);
    }
}