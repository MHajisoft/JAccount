using Account.Common.Enum;

namespace Account.Common.Dto;

public class TransactionDto : BaseDto
{
    public long PersonId { get; set; }

    public long AccountId { get; set; }

    public long CostId { get; set; }

    //ToDo شاید بهتر باشد اجباری گردد
    public long? ReasonId { get; set; }

    public string? Description { get; set; }

    public BudgetType BudgetType { get; set; }

    public long Budget { get; set; }

    public long? BudgetIncome => BudgetType == BudgetType.Income ? Budget : null;

    public long? BudgetCost => BudgetType == BudgetType.Cost ? Budget : null;
}