using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class CostController(IGeneralTypeService service) : GeneralTypeController(service, AccountConstant.Cost);