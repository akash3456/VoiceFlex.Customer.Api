using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Validators
{
    public class Validator : IValidator
    {
        public Validator() { }

        public List<string> Validate(Account account)
        {
            List<string> errors = new List<string>();

            if(account == null)
            {
                errors.Add("account does not exist");
            }

            if(account.accountStatus == AccountStatus.Suspended)
            {
                errors.Add("Phone Number cannot be assigned");
            }

            return errors;
        }
    }
}
