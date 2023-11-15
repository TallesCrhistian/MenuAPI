using MenuAPI.Identity.Data;
using MenuAPI.Identity.Interfaces;

namespace MenuAPI.Identity.Services
{
    public class WorkUnitIdentity : IWorkUnitIdentity
    {
        private readonly IdentityDataContext _indentityDataContext;

        public WorkUnitIdentity(IdentityDataContext indentityDataContext)
        {
            _indentityDataContext = indentityDataContext;
            _indentityDataContext.Database.BeginTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _indentityDataContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await _indentityDataContext.Database.CommitTransactionAsync();
        }

        public void Rollback()
        {
            _indentityDataContext.Database.RollbackTransaction();
        }

        public async Task DeleteAsync()
        {
            await _indentityDataContext.Database.EnsureDeletedAsync();
        }
    }
}
