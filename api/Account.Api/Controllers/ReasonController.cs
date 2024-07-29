using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class ReasonController(IGeneralTypeService service) : GeneralTypeController(service, AccountConstant.Reason);