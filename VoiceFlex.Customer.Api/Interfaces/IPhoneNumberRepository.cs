using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Interfaces
{
    public interface IPhoneNumberRepository
    {
        void Add(PhoneNumber phoneNumber);     
        
        PhoneNumber GetByRef(int referenceNumber);

        PhoneNumber GetByPhoneNumber(string  phoneNumber);

        List<PhoneNumber> GetAll(int accountId);
    }
}
