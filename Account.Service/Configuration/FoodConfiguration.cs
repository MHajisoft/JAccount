using Account.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class FoodConfiguration : BaseEntityConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.CookingDate).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(30).IsUnicode(false);
        builder.HasMany(x => x.IngredientInfoList).WithMany();
    }
}