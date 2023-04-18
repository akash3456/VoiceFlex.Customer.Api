using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Observers
{
    public class AccountObserver : IObserver<Account>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountObserver(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public void OnCompleted()
        {
            Console.WriteLine("Account Status Updated");
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Account value)
        {
            //update the value
            _accountRepository.Update(value);
        }
    }
}
