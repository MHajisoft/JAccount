using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class RelativeTypeController(IGeneralTypeService service)
    : GeneralTypeController(service, AccountConstant.RelativeType);