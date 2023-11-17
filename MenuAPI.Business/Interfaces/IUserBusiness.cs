using MenuAPI.Shared.DTOs;

namespace MenuAPI.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDTO> Delete(Guid id);
        Task<UserDTO> Read(Guid id);
        Task<UserDTO> Update(UserDTO userDTO, Guid id);
    }
}