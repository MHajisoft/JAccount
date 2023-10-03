using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class IdentityService : IIdentityService
{
    private readonly AppUserManager _userManager;
    private readonly AppSigninManager _signinManager;
    
    public IdentityService(AppUserManager userManager, AppSigninManager signinManager)
    {
        _userManager = userManager;
        _signinManager = signinManager;
    }
    
    public Task AddUser(string username)
    {
        throw new NotImplementedException();
    }

    public Task Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task SetPassword(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task ResetPassword(string username, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task AddRoleToUser(string username, string role)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRoleFromUser(string username, string role)
    {
        throw new NotImplementedException();
    }

    public Task AddRole(string role)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRole(string role)
    {
        throw new NotImplementedException();
    }
}