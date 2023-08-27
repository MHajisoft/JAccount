using Account.Common.Enum;

namespace Account.Common.Dto;

public class PersonDto : BaseDto
{
    public string FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FatherFirstName { get; set; }

    public long? FatherId { get; set; }

    public string? RelativeFirstName { get; set; }

    public long? RelativeId { get; set; }

    public long? RelativeTypeId { get; set; }

    public Gender Gender { get; set; }

    public bool IsAlive { get; set; }

    public bool IsHaj { get; set; }

    public bool IsHolyVisit { get; set; }

    public byte[]? Thumbnail { get; set; }
}