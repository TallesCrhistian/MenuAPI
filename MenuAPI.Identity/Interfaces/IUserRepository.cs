using Microsoft.AspNetCore.Identity;

namespace MenuAPI.Identity.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityUser> Delete(string id);
        Task<List<IdentityUser>> List(IdentityUser identityUser);
        Task<IdentityUser> Read(string id);
        Task<IdentityUser> Update(IdentityUser identityUser);
    }
}