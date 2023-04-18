using Microsoft.Identity.Client;
using VoiceFlex.Customer.Api.Database;
using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext Context)
        {
            _context = Context;            
        }



        public bool Add(Account account)
        {
            this._context.accounts.Add(account);
            return this._context.ChangeTracker.Entries().Any();
        }

        public bool Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public Account Get(string name)
        {
           return this._context.accounts.Where(c=>c.name == name).FirstOrDefault();
        }

        public Account GetAccount(int account_id)
        {
            return _context.accounts.Where(c=>c.account_id == account_id).FirstOrDefault();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<PhoneNumber> GetPhoneNumbers(string accountId)
        {
            throw new NotImplementedException();
        }

        public void PopulateDatasource()
        {
            List<Account> accounts = new List<Account>
            {
                new Account { account_id = 1, accountStatus = AccountStatus.Suspended, email = "akashpaul0210@gmail.com", name = "Akash Paul" },
                new Account { account_id = 2, accountStatus = AccountStatus.Active, email = "gauravp987@gmail.com", name = "Gaurav Paul" },
                new Account { account_id = 3, accountStatus = AccountStatus.Active, email = "nathanronchetti@gmail.com", name = "Nathan Rochetti" },
                new Account { account_id = 4, accountStatus = AccountStatus.Active, email = "davidLynch@gmail.com", name = "David Lynch" }
            };

            foreach (var account in accounts)
            {
                this._context.accounts.Add(account);                
            }
            this._context.SaveChanges();
        }


        public bool Update(Account account)
        {
            this._context.Update(account);
            return this._context.ChangeTracker.Entries().Any();
        }
    }
}
