using MenuAPI.Shared.DTOs;
using MenuAPI.Shared.ViewModels.Enterprise;

namespace MenuAPI.Services.Interfaces
{
    public interface IEnterpriseServices
    {
        Task<ServiceResponseDTO<EnterpriseViewModel>> Create(EnterpriseCreateViewModel enterpriseCreateViewModel);
        Task<ServiceResponseDTO<EnterpriseViewModel>> Delete(Guid id);
        Task<ServiceResponseDTO<EnterpriseViewModel>> Read(Guid id);
        Task<ServiceResponseDTO<EnterpriseViewModel>> Update(EnterpriseUpdateViewModel enterpriseUpdateViewModel, Guid id);
    }
}