

using System.ComponentModel.DataAnnotations;

namespace VoiceFlex.Customer.Api.Models
{
    public class Account
    {
        [Key]
        [Range(0, 5000)]        
        public int account_id { get; set; }

        public string name { get; set; }

        public string email { get; set; }       

        public AccountStatus accountStatus { get; set; } = AccountStatus.Active;
    }

    public enum AccountStatus
    {
        Active,
        Suspended
    }
}
