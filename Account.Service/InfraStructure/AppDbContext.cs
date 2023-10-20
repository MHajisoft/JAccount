using Account.Common.Base;
using Account.Common.Entity;
using Account.Common.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Account.Service.InfraStructure;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
{
    #region Constructor

    private readonly IHttpContextAccessor _httpContextAccessor;

    public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
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

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var date = DateTime.Now;
        var userId = await GetUserId(_httpContextAccessor);

        #region Create Data

        var addedEntities = ChangeTracker.Entries().Where(entry => entry is { Entity: BaseEntity, State: EntityState.Added }).ToList();

        addedEntities.ForEach(entry =>
        {
            var entity = entry.Entity as BaseEntity;

            entity!.CreateDate = date;
            entity.CreateUserId = userId.Value;
        });

        #endregion

        #region Update Data

        var editedEntities = ChangeTracker.Entries().Where(entry => entry is { Entity: BaseEntity, State: EntityState.Modified }).ToList();

        editedEntities.ForEach(entry =>
        {
            var entity = entry.Entity as BaseEntity;

            entity!.UpdateDate = date;
            entity!.UpdateUserId = userId;
        });

        #endregion

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private static long? _systemUserId;

    private async Task<long?> GetUserId(IHttpContextAccessor httpContextAccessor)
    {
        _systemUserId ??= (await Users.FirstOrDefaultAsync(x => x.UserName!.Equals(AccountConstant.SystemUsername)))?.Id;

        var result = httpContextAccessor.HttpContext?.User.GetUserId();

        return result ?? _systemUserId;
    }

    #endregion
}