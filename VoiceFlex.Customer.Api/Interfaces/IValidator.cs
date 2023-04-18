using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Interfaces
{
    public interface IValidator
    {
        List<string> Validate(Account account);
    }
}
