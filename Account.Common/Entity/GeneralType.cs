using Microsoft.EntityFrameworkCore;

namespace Account.Common.Entity;

public class GeneralType : BaseEntity
{
    public string Category { get; set; }

    public string Title { get; set; }

    public int OrderIndex { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Transaction> TransactionAccountTypes { get; set; }

    public ICollection<Transaction> TransactionCostTypes { get; set; }
}