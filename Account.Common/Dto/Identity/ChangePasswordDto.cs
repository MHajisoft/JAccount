namespace Account.Common.Dto.Identity;

public class ChangePasswordDto
{
    public string Username { get; set; }

    public string OldPassword { get; set; }

    public string NewPassword { get; set; }
}