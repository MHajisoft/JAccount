namespace Account.Common.Dto;

public class AttachmentDto : BaseDto
{
    public byte[] Data { get; set; }

    public string Name { get; set; }
    
    public long TransactionId { get; set; }
}