using VoiceFlex.Customer.Api.Database;
using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Repository
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly AppDbContext _context;

        public PhoneNumberRepository(AppDbContext appDbContext) 
        {         
            _context = appDbContext;
        }


        public void Add(PhoneNumber phoneNumber)
        {
            _context.phoneNumbers.Add(phoneNumber);
        }

        public PhoneNumber GetByRef(int referenceNumber)
        {
            return _context.phoneNumbers.Where(c=>c.referenceId == referenceNumber).FirstOrDefault();
        }

        public List<PhoneNumber> GetAll(int accountId)
        {
            return _context.phoneNumbers.Where(x => x.accountId == accountId).ToList();
        }

        public PhoneNumber GetByPhoneNumber(string phoneNumber)
        {
            return _context.phoneNumbers.Where(c=>c.phoneNumber == phoneNumber).FirstOrDefault();
        }
    }
}
