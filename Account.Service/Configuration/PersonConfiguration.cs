using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class PersonConfiguration : BaseEntityConfiguration<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired().IsUnicode();
        builder.Property(x => x.LastName).HasMaxLength(70).IsRequired(false).IsUnicode();

        builder.HasOne(bp => bp.Father).WithMany().HasForeignKey(x => x.FatherId).IsRequired(false);
        builder.HasOne(bp => bp.Relative).WithMany().HasForeignKey(x => x.RelativeId).IsRequired(false);
        builder.HasOne(bp => bp.RelativeType).WithMany().HasForeignKey(x => x.RelativeTypeId).IsRequired(false);

        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.IsAlive).IsRequired();
        builder.Property(x => x.IsHaj).IsRequired();
        builder.Property(x => x.IsHolyVisit).IsRequired();
        builder.Property(x => x.Thumbnail).IsRequired(false);
    }
}