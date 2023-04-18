using Microsoft.EntityFrameworkCore;
using VoiceFlex.Customer.Api.Models;

namespace VoiceFlex.Customer.Api.Database
{
    public class AppDbContext : DbContext
    {

        protected readonly IConfiguration _Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public DbSet<Account> accounts { get; set; }

        public DbSet<PhoneNumber> phoneNumbers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("AccountDatabase");
        }
    }
}
