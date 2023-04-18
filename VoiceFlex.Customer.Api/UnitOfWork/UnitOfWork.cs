using VoiceFlex.Customer.Api.Database;
using VoiceFlex.Customer.Api.Interfaces;

namespace VoiceFlex.Customer.Api.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext) 
        {         
            _appDbContext = appDbContext;
        }

        public int SaveChanges()
        {
            return this._appDbContext.SaveChanges();
        }
    }
}
