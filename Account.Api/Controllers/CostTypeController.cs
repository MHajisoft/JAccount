using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class CostTypeController : GeneralTypeController
{
    public CostTypeController(IGeneralTypeService service, string category = AccountConstant.CostType) : base(service, category)
    {
    }
}