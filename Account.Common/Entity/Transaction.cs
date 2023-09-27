using Account.Common.Enum;

namespace Account.Common.Entity;

public class Transaction : BaseEntity
{
    public Person Person { get; set; }
    public long PersonId { get; set; }

    public GeneralType AccountType { get; set; } // نحوه دریافت و هزینه : نقدی، کارت، حواله
    public long AccountTypeId { get; set; }

    public GeneralType CostType { get; set; } // نوع هزینه : عمومی، محرم، صفر
    public long CostTypeId { get; set; }

    public BudgetType BudgetType { get; set; }

    public long Budget { get; set; }

    public long? BudgetIncome => BudgetType == BudgetType.Income ? Budget : null;

    public long? BudgetCost => BudgetType == BudgetType.Cost ? Budget : null;

    public ICollection<Attachment> Attachments { get; set; }
}