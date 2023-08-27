namespace Account.Common.Dto;

public class BaseDto
{
    public long Id { get; set; }

    public bool IsFresh() => Id == 0;
}