using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class AccountTypeController : GeneralTypeController
{
    public AccountTypeController(IGeneralTypeService service, string category = AccountConstant.AccountType) : base(service, category)
    {
    }
}