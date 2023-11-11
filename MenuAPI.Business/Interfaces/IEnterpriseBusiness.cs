using MenuAPI.Shared.DTOs;

namespace MenuAPI.Business.Interfaces
{
    public interface IEnterpriseBusiness
    {
        Task<EnterpriseDTO> Create(EnterpriseDTO enterpriseDTO);
        Task<EnterpriseDTO> Delete(Guid id);
        Task<EnterpriseDTO> Read(Guid id);
        Task<EnterpriseDTO> Update(EnterpriseDTO enterpriseDTO, Guid id);
    }
}