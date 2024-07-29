namespace Account.Common.IService;

public interface IIdentityService
{
    Task AddUser(string username);
    Task Login(string username, string password);
    Task SetPassword(string username, string password);
    Task ResetPassword(string username, string oldPassword, string newPassword);
    Task AddRoleToUser(string username, string role);
    Task RemoveRoleFromUser(string username, string role);
    Task AddRole(string role);
    Task DeleteRole(string role);
}