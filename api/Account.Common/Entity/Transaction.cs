using Account.Common.Enum;

namespace Account.Common.Entity;

public class Transaction : BaseEntity
{
    public Person? Person { get; set; }
    public long? PersonId { get; set; }

    public GeneralType? Account { get; set; } // حساب: ملت ، مهر، نقدی، چک
    public long AccountId { get; set; }

    public GeneralType? Cost { get; set; } // نوع هزینه : عمومی، محرم، صفر
    public long CostId { get; set; }

    //ToDo شاید بهتر باشد اجباری گردد
    public GeneralType? Reason { get; set; } // شرح عملکرد به صورت تعاریف پیش فرض
    public long? ReasonId { get; set; }

    public string? Description { get; set; }
    
    public BudgetType BudgetType { get; set; }

    public long Budget { get; set; }

    public long? BudgetIncome => BudgetType == BudgetType.Income ? Budget : null;

    public long? BudgetCost => BudgetType == BudgetType.Cost ? Budget : null;

    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}