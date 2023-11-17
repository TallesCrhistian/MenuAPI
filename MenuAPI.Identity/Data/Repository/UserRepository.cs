using MenuAPI.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MenuAPI.Identity.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDataContext _identityDbContext;


        public UserRepository(IdentityDataContext identityDbUser)
        {
            _identityDbContext = identityDbUser;
        }

        public async Task<IdentityUser> Read(string id)
        {
            IdentityUser user = await _identityDbContext.Users.FirstOrDefaultAsync(e => e.Id == id);

            return user;
        }

        public async Task<IdentityUser> Update(IdentityUser identityUser)
        {
            IdentityUser? existingUser = await _identityDbContext.Users.FirstOrDefaultAsync(e => e.Id == identityUser.Id);

            if (existingUser is not null)
            {
                if (existingUser.PhoneNumber != identityUser.PhoneNumber)
                {
                    existingUser.PhoneNumber = identityUser.PhoneNumber;
                }

                if (existingUser.Email != identityUser.Email)
                {
                    existingUser.Email = identityUser.Email;
                    existingUser.NormalizedEmail = identityUser.Email.ToUpper();
                }

                if (existingUser.UserName != identityUser.UserName)
                {
                    existingUser.UserName = identityUser.UserName;
                    existingUser.NormalizedUserName = identityUser.UserName.ToUpper();
                }


                await _identityDbContext.SaveChangesAsync();

                return existingUser;
            }

            else
            {
                return existingUser;
            }
        }


        public async Task<IdentityUser> Delete(string id)
        {
            IdentityUser? user = await _identityDbContext.Users.FirstOrDefaultAsync(e => e.Id == id);

            if (user is not null)
            {
                _identityDbContext.Users.Remove(user);
                await _identityDbContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<List<IdentityUser>> List(IdentityUser identityUser)
        {
            IQueryable<IdentityUser> query = _identityDbContext.Users;

            if (!string.IsNullOrEmpty(identityUser.UserName))
            {
                query = query.Where(u => u.UserName == identityUser.UserName);
            }

            if (!string.IsNullOrEmpty(identityUser.PhoneNumber))
            {
                query = query.Where(u => u.PhoneNumber == identityUser.PhoneNumber);
            }

            if (!string.IsNullOrEmpty(identityUser.Email))
            {
                query = query.Where(u => u.Email == identityUser.Email);
            }

            if (string.IsNullOrEmpty(identityUser.UserName) && string.IsNullOrEmpty(identityUser.PhoneNumber) && string.IsNullOrEmpty(identityUser.Email))
            {
                return await query.ToListAsync();
            }

            return await query.Where(u =>
                (string.IsNullOrEmpty(identityUser.UserName) || u.UserName == identityUser.UserName) &&
                (string.IsNullOrEmpty(identityUser.PhoneNumber) || u.PhoneNumber == identityUser.PhoneNumber) &&
                (string.IsNullOrEmpty(identityUser.Email) || u.Email == identityUser.Email))
                .ToListAsync();
        }
    }
}