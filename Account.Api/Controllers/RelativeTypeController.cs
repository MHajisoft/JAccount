using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class RelativeTypeController : GeneralTypeController
{
    public RelativeTypeController(IGeneralTypeService service) : base(service, AccountConstant.RelativeType)
    {
    }
}