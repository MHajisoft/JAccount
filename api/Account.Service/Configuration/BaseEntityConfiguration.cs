using Account.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(x => x.Version).IsRequired().IsRowVersion().IsConcurrencyToken();

        builder.Property(x => x.CreateDate).IsRequired();
        builder.HasOne(bp => bp.CreateUser).WithMany().HasForeignKey(x => x.CreateUserId).IsRequired().OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.HasOne(bp => bp.UpdateUser).WithMany().HasForeignKey(x => x.UpdateUserId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
    }
}