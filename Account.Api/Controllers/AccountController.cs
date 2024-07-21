using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class AccountController(IGeneralTypeService service) : GeneralTypeController(service, AccountConstant.Account);