using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class AccountController : GeneralTypeController
{
    public AccountController(IGeneralTypeService service) : base(service, AccountConstant.Account)
    {
    }
}