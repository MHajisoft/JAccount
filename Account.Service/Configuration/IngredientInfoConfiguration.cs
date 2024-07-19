using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class IngredientInfoConfiguration : BaseEntityConfiguration<IngredientInfo>
{
    public void Configure(EntityTypeBuilder<IngredientInfo> builder)
    {
        base.Configure(builder);
    }
}