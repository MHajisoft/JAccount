namespace Account.Common.Entity;

public class GeneralType : BaseEntity
{
    public string Category { get; set; }

    public string Title { get; set; }

    public int OrderIndex { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Transaction> TransactionAccountTypes { get; set; } = new List<Transaction>();

    public ICollection<Transaction> TransactionCostTypes { get; set; } = new List<Transaction>();
    
    public ICollection<Transaction> TransactionItemTypes { get; set; } = new List<Transaction>();

    public ICollection<Person> RelativeTypes { get; set; } = new List<Person>();
}