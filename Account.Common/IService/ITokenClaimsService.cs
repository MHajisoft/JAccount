namespace Account.Common.IService;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
    Task<string> ValidateTokenAsync(string token);
}
