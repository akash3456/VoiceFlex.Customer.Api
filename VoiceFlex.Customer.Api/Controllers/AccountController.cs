using Microsoft.AspNetCore.Mvc;
using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;
using VoiceFlex.Customer.Api.Observables;
using VoiceFlex.Customer.Api.Observers;
using VoiceFlex.Customer.Api.UnitOfWork;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoiceFlex.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountObservable accountObservable;
        private readonly AccountObserver accountObserver;
        private readonly IAccountRepository repository;
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IUnitOfWork work;        

        public AccountController(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IPhoneNumberRepository phoneRepository)
        {
            work = unitOfWork;
            repository = accountRepository;            
            _phoneNumberRepository = phoneRepository;
            accountObserver = new AccountObserver(accountRepository);
        }

        [HttpGet()]
        public ActionResult Get(string phoneNumber, string name)
        {
            //call phone repo
            var getPhoneNumber = _phoneNumberRepository.GetByPhoneNumber(phoneNumber);

            if(getPhoneNumber == null)
            {
                return NotFound("Phone Number does not exist");
            }

            var getAccount = repository.Get(name);

            if(getAccount == null)
            {
                return NotFound($"Account does not exist for this name : {name}");
            }

            var returnResults = new AccountResults();
            returnResults.account = getAccount;
            returnResults.phoneNumbers = new List<PhoneNumber> { getPhoneNumber };

            return Ok();
        }

        // POST api/<AccountController>
        [HttpPost]
        public ActionResult Post([FromBody] Account value)
        {

            var response = repository.Add(value);
            work.SaveChanges();
            if (!response)
                return BadRequest();
            return Ok(response);
        }

        [HttpPut("UpdateAccountStatus")]
        public ActionResult UpdateAccountStatus([FromBody] int status, int account_id)
        {
            var getAccount = repository.GetAccount(account_id);

            if (getAccount != null)
            {
                //then perform the update
                accountObservable = new AccountObservable(getAccount);
                accountObservable.Subscribe(accountObserver);
                accountObservable.UpdateAccountStatus(status);
                work.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
