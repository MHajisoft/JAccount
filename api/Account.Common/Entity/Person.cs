using Account.Common.Enum;

namespace Account.Common.Entity;

public class Person : BaseEntity
{
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NickName { get; set; }

    public Person? Father { get; set; }
    public long? FatherId { get; set; }

    public Person? Relative { get; set; }
    public long? RelativeId { get; set; }

    public GeneralType? RelativeType { get; set; }
    public long? RelativeTypeId { get; set; }

    public Gender Gender { get; set; }

    public bool IsAlive { get; set; }

    public bool IsHaj { get; set; }

    public bool IsHolyVisit { get; set; }

    public byte[]? Thumbnail { get; set; }

    public string? Description { get; set; }
    
    public string? Mobile { get; set; }
    
    public string? NationalCode { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public ICollection<Person> Fathers { get; set; } = new List<Person>();
    
    public ICollection<Person> Relatives { get; set; } = new List<Person>();
}