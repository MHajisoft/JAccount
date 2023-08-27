namespace Account.Common.Entity;

public class GeneralType : BaseEntity
{
    public string Category { get; set; }

    public string Title { get; set; }

    public int OrderIndex { get; set; }

    public bool IsActive { get; set; }
}