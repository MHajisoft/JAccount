namespace Account.Common.Entity;

public class BaseEntity
{
    public long Id { get; set; }

    public AppUser CreateUser { get; set; }
    public long CreateUserId { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsFresh() => Id == 0;
}