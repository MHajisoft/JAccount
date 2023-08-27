using Account.Common.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Account.Service.InfraStructure;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
{
    public DbSet<Person> Persons { get; set; }

    public DbSet<GeneralType> GeneralTypes { get; set; }

    public DbSet<Transaction> Transactions { get; set; }
}