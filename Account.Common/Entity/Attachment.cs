namespace Account.Common.Entity;

public class Attachment : BaseEntity
{
    public byte[] Data { get; set; }

    public string Name { get; set; }
    
    public Transaction Transaction { get; set; }
    public long TransactionId { get; set; }
}