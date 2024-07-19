using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class CostController : GeneralTypeController
{
    public CostController(IGeneralTypeService service) : base(service, AccountConstant.Cost)
    {
    }
}