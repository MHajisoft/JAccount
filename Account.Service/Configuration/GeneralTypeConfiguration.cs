using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class GeneralTypeConfiguration : BaseEntityConfiguration<GeneralType>
{
    public override void Configure(EntityTypeBuilder<GeneralType> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Category).IsRequired().HasMaxLength(30).IsUnicode(false);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50).IsUnicode();
        builder.Property(x => x.OrderIndex).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
    }
}