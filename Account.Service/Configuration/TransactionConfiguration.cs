using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class TransactionConfiguration : BaseEntityConfiguration<Transaction>
{
    public override void Configure(EntityTypeBuilder<Transaction> builder)
    {
        base.Configure(builder);

        builder.HasOne(bp => bp.Person).WithMany(x => x.Transactions).HasForeignKey(x => x.PersonId).IsRequired(false);
        builder.HasOne(bp => bp.Account).WithMany(x => x.TransactionAccountTypes).HasForeignKey(x => x.AccountId).IsRequired();
        builder.HasOne(bp => bp.Cost).WithMany(x => x.TransactionCostTypes).HasForeignKey(x => x.CostId).IsRequired();
        builder.HasOne(bp => bp.Reason).WithMany(x => x.TransactionItemTypes).HasForeignKey(x => x.ReasonId).IsRequired(false);

        builder.Property(x => x.BudgetType).IsRequired();
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500).IsUnicode();

        builder.Ignore(x => x.BudgetIncome);
        builder.Ignore(x => x.BudgetCost);
    }
}