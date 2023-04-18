using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Observables
{
    //subject to be updated. 
    public class AccountObservable : IObservable<Account>
    {
        
        private List<IObserver<Account>> observers { get; set; }
        private Account account { get; set; }


        public AccountObservable(Account account)
        {
            //track the observers
            observers = new List<IObserver<Account>>();
            this.account = account;
        }


        public IDisposable Subscribe(IObserver<Account> observer)
        {
            observers.Add(observer);
            observer.OnNext(account);
            return new Unsubscriber(observers, observer);
        }
        

        public void UpdateAccountStatus(int status)
        {
            account.accountStatus = (AccountStatus)status;
            foreach (var observer in observers) 
            {             
                observer.OnNext(account);
                observer.OnCompleted();
            }

        }
    }
}
