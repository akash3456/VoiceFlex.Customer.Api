using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace VoiceFlex.Customer.Api.Models
{    
    public class PhoneNumber
    {
        [Key]                
        [Range(0, 150)]
        public int referenceId { get; set; }

        public int accountId {get;set;}


        [MinLength(11, ErrorMessage = "Number should be at least 11 characters")]
        [Phone()]
        public string phoneNumber { get; set; }

        public Type phoneNumberType { get; set; }

    }

    public enum Type
    {
        Home,
        Work,
        Mobile
    }
}
