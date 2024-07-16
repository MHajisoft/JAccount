using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class ReasonController : GeneralTypeController
{
    public ReasonController(IGeneralTypeService service) : base(service, AccountConstant.Reason)
    {
    }
}