using Account.Common.Entity;

namespace Account.Common.Base;

public static class AccountRoles
{
    public static AppRole Admin = new() { Name = nameof(Admin), Title = "مدیر" };
    public static AppRole User = new() { Name = nameof(User), Title = "کاربر" };
}