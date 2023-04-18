using Microsoft.AspNetCore.Mvc;
using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberRepository PhoneNumberRepository;
        private readonly IAccountRepository AccountRepository;
        private readonly IUnitOfWork unitOfWork;        
        private readonly IValidator _validator;

        public PhoneNumberController(IUnitOfWork workUnit, IPhoneNumberRepository phoneNumberRepository, IAccountRepository accountRepository, IValidator validator)
        {
            unitOfWork = workUnit;
            PhoneNumberRepository = phoneNumberRepository;
            AccountRepository = accountRepository;
            _validator = validator;

        }

        [HttpPost]
        public ActionResult Post([FromBody] PhoneNumber phoneNumber)
        {
            PhoneNumberRepository.Add(phoneNumber);
            if (unitOfWork.SaveChanges() == 1)
                return Ok(unitOfWork.SaveChanges());
            return BadRequest();
        }

        [HttpGet("Get")]
        public ActionResult Get(int phoneNumberRef) 
        {
            var response = PhoneNumberRepository.GetByRef(phoneNumberRef);     
            return response == null ? Ok() : BadRequest();
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll(int accountId) { 
        
            var response = PhoneNumberRepository.GetAll(accountId);
            return Ok(response);
        }

        [HttpPut("AssignPhoneNumbers")]
        public ActionResult AssignPhoneNumbers(List<PhoneNumber> phoneNumbers, int accountId)
        {
            var getAccount = AccountRepository.GetAccount(accountId);
            var messages = _validator.Validate(getAccount);

            if (messages.Count > 0)
            {
                return BadRequest(messages.FirstOrDefault());
            }            

            foreach (var phoneNumber in phoneNumbers) 
            {
                PhoneNumberRepository.Add(phoneNumber);
            }

            unitOfWork.SaveChanges();

            return messages.Count  == 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public void Delete()
        {

        }

    }
}
