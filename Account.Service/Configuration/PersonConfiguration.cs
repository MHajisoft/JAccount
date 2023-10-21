using Account.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class PersonConfiguration : BaseEntityConfiguration<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired().IsUnicode();
        builder.Property(x => x.LastName).HasMaxLength(70).IsRequired(false).IsUnicode();
        builder.Property(x => x.NickName).HasMaxLength(100).IsRequired(false).IsUnicode();

        builder.HasOne(bp => bp.Father).WithMany(x => x.Fathers).HasForeignKey(x => x.FatherId).IsRequired(false);
        builder.HasOne(bp => bp.Relative).WithMany(x => x.Relatives).HasForeignKey(x => x.RelativeId).IsRequired(false);
        builder.HasOne(bp => bp.RelativeType).WithMany(x => x.RelativeTypes).HasForeignKey(x => x.RelativeTypeId).IsRequired(false);

        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.IsAlive).IsRequired();
        builder.Property(x => x.IsHaj).IsRequired();
        builder.Property(x => x.IsHolyVisit).IsRequired();
        builder.Property(x => x.Thumbnail).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500).IsUnicode();
        builder.Property(x => x.Mobile).IsRequired(false).HasMaxLength(11).IsFixedLength().IsUnicode(false);
        builder.Property(x => x.NationalCode).IsRequired(false).HasMaxLength(10).IsFixedLength().IsUnicode(false);

        builder.HasIndex(x => x.NationalCode).HasFilter($"{nameof(Person.NationalCode)} IS NOT NULL");
        builder.HasIndex(x => new
        {
            x.FirstName,
            x.LastName,
            x.FatherId
        }).IsUnique().HasFilter($"{nameof(Person.FatherId)} IS NOT NULL");
        builder.HasIndex(x => new
        {
            x.FirstName,
            x.LastName,
            x.RelativeId
        }).IsUnique().HasFilter($"{nameof(Person.RelativeId)} IS NOT NULL");
    }
}