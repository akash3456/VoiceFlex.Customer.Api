using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Observables
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Account>> _observers;
        private IObserver<Account> _observer;

        public Unsubscriber(List<IObserver<Account>> observers,IObserver<Account> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }
}