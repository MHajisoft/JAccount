using Account.Common.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Account.Service.InfraStructure;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
{
    #region Constructor

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    #endregion

    #region Tables

    public DbSet<Person> Persons { get; set; }

    public DbSet<GeneralType> GeneralTypes { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    #endregion

    #region Method

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            entityType.GetForeignKeys()
                .Where(fk => fk is { IsOwnership: false, DeleteBehavior: DeleteBehavior.Cascade })
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
        }

        base.OnModelCreating(builder);
    }

    #endregion
}