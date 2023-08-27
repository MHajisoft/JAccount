namespace Account.Common.Dto;

public class GeneralTypeDto : BaseDto
{
    public string Category { get; set; }

    public string Title { get; set; }

    public int OrderIndex { get; set; }

    public bool IsActive { get; set; }
}