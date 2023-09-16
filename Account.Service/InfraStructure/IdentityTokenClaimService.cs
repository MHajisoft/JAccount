using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Account.Common.Base;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Account.Service.InfraStructure;

public class IdentityTokenClaimService : ITokenClaimsService
{
    private readonly UserManager<AppUser> _userManager;

    public IdentityTokenClaimService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> GetTokenAsync(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AccountConstant.JwtSecretKey);
        var user = await _userManager.FindByNameAsync(userName);
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor { Subject = new ClaimsIdentity(claims.ToArray()), Expires = DateTime.UtcNow.AddDays(7), SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<string> ValidateTokenAsync(string token)
    {
        if (token == null)
            return "";

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AccountConstant.JwtSecretKey);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userName = jwtToken.Claims.First(x => x.Type == "unique_name").Value;

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                return "";

            // return user name from JWT token if validation successful
            return userName;
        }
        catch
        {
            // return empty if validation fails
            return "";
        }
    }
}
