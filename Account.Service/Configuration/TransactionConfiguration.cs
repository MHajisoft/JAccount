using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class TransactionConfiguration : BaseEntityConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.HasOne(bp => bp.Person).WithMany(x => x.Transactions).HasForeignKey(x => x.PersonId).IsRequired();
        builder.HasOne(bp => bp.AccountType).WithMany(x => x.TransactionAccountTypes).HasForeignKey(x => x.AccountTypeId).IsRequired();
        builder.HasOne(bp => bp.CostType).WithMany(x => x.TransactionCostTypes).HasForeignKey(x => x.CostTypeId).IsRequired();

        builder.Property(x => x.BudgetType).IsRequired();

        builder.Ignore(x => x.BudgetIncome);
        builder.Ignore(x => x.BudgetCost);
    }
}