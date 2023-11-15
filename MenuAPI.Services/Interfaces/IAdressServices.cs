using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Adress;

namespace MenuAPI.Services.Interfaces
{
    public interface IAdressServices
    {
        Task<ServiceResponseDTO<AdressViewModel>> Create(AdressCreateViewModel adressCreateViewModel);
        Task<ServiceResponseDTO<AdressViewModel>> Delete(Guid id);
        Task<ServiceResponseDTO<AdressViewModel>> Read(Guid id);
        Task<ServiceResponseDTO<AdressViewModel>> Update(AdressUpdateViewModel adressUpdateViewModel, Guid id);
    }
}