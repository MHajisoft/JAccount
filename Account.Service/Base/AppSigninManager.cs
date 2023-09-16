using Account.Common.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Account.Service.Base;

public class AppSigninManager : SignInManager<AppUser>
{
    public AppSigninManager(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<AppUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<AppUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<AppUser> userConfirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, userConfirmation)
    {
    }
}