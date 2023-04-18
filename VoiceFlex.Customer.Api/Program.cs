using Microsoft.EntityFrameworkCore;
using VoiceFlex.Customer.Api.Database;
using VoiceFlex.Customer.Api.Interfaces;
using VoiceFlex.Customer.Api.Models;
using VoiceFlex.Customer.Api.Repository;
using VoiceFlex.Customer.Api.UnitOfWork;
using VoiceFlex.Customer.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>( o => o.UseInMemoryDatabase("AccountDatabase"));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();




builder.Services.AddTransient<IValidator, Validator>();
builder.Services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<AppDbContext>();

List<Account> accounts = new List<Account>
            {
                new Account { account_id = 1, accountStatus = AccountStatus.Suspended, email = "akashpaul0210@gmail.com", name = "Akash Paul" },
                new Account { account_id = 2, accountStatus = AccountStatus.Active, email = "gauravp987@gmail.com", name = "Gaurav Paul" },
                new Account { account_id = 3, accountStatus = AccountStatus.Active, email = "nathanronchetti@gmail.com", name = "Nathan Rochetti" },
                new Account { account_id = 4, accountStatus = AccountStatus.Active, email = "davidLynch@gmail.com", name = "David Lynch" }
            };

foreach (var account in accounts) {

    db.accounts.Add(account);
}

db.SaveChanges();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
