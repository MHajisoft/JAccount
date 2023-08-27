using Microsoft.AspNetCore.Identity;

namespace Account.Common.Entity;

public class AppUser : IdentityUser<long>
{
    public string DisplayName { get; set; }

    public bool IsActive { get; set; }
}