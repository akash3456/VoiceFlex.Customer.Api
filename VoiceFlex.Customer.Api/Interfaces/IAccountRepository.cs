using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Interfaces
{
    public interface IAccountRepository
    {
        void PopulateDatasource();

        bool Add(Account account);  

        bool Update(Account account);


        bool Delete(Account account);

        Account GetAccount(int account_id);

        Account Get(string name);

        List<PhoneNumber> GetPhoneNumbers(string accountId);

        IQueryable<Account> GetAll();

        IEnumerable<Account> GetAccounts();        
    }
}
