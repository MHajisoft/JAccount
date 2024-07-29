using Microsoft.AspNetCore.Identity;

namespace Account.Common.Entity;

public class AppRole : IdentityRole<long>
{
    public string Title { get; set; }
}