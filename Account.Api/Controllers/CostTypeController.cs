using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class CostTypeController : GeneralTypeController
{
    public CostTypeController(IGeneralTypeService service) : base(service, AccountConstant.Cost)
    {
    }
}