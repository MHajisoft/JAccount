using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Base;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    protected Response ResponseResult { get; } = new(null);
}