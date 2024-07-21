using Account.Api.Base;
using Account.Common.Base;
using Account.Common.Dto.Identity;
using Account.Common.IService;
using Account.Common.Resource;
using Account.Service.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Account.Api.Controllers;

public class IdentityController(
    AppUserManager userManager,
    AppSigninManager signInManager,
    ITokenClaimsService tokenClaimsService,
    IHttpContextAccessor httpContextAccessor)
    : BaseController
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await userManager.FindByNameAsync(dto.Username);
        if (user == null)
            return ResponseResult.AddError(MembershipResource.Error_UsernameOrPasswordIsNotValid);

        var result = await signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, true);

        //ToDo پیاده سازی دو مرحله ای
        // if (result.RequiresTwoFactor)
        //     throw new Exception("Two Factor is not Implemented");

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                Log.Logger.Error(MembershipResource.Error_UserLockout);
                return ResponseResult.AddError(MembershipResource.Error_UserLockout);
            }

            Log.Logger.Error(MembershipResource.Error_UsernameOrPasswordIsNotValid);
            return ResponseResult.AddError(MembershipResource.Error_UsernameOrPasswordIsNotValid);
        }

        return ResponseResult.SetData(new
        {
            token = await tokenClaimsService.GetTokenAsync(dto.Username),
            user.UserName,
            user.DisplayName
        });
    }

    [HttpPost]
    [Authorize(Roles = nameof(AccountRoles.User))]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
    {
        if (httpContextAccessor.HttpContext?.User.Identity?.Name != dto.Username)
            return ResponseResult.AddError(MembershipResource.Error_CurrentUserMismatch);

        var user = await userManager.FindByNameAsync(dto.Username);
        var result = await userManager.ChangePasswordAsync(user!, dto.OldPassword, dto.NewPassword);
        if (result.Succeeded)
            return ResponseResult.AddSuccess();

        foreach (var item in result.Errors)
            ResponseResult.AddError($"{item.Code} - {item.Description}");

        return ResponseResult;
    }

    [HttpPost]
    [Authorize(Roles = nameof(AccountRoles.Admin))]
    public async Task<IActionResult> SetPassword([FromBody] ChangePasswordDto dto)
    {
        var user = await userManager.FindByNameAsync(dto.Username);
        var result = await userManager.ChangePasswordAsync(user!, dto.OldPassword, dto.NewPassword);
        //ToDo این مورد باید پیاده سازی شود
        //var result = await _userManager.ResetPasswordAsync(user!, dto.OldPassword, dto.NewPassword);
        if (result.Succeeded)
            return ResponseResult.AddSuccess();

        foreach (var item in result.Errors)
            ResponseResult.AddError($"{item.Code} - {item.Description}");

        return ResponseResult;
    }
}