using System.Security.Claims;

namespace Account.Common.Util
{
    public static class IdentityExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Name)?.Value;
        }

        public static long? GetUserId(this ClaimsPrincipal user)
        {
            var value = user.Claims.FirstOrDefault(i => i.Type == ClaimTypes.UserData)?.Value;
            return value is null ? null : Convert.ToInt64(value);
        }
    }
}