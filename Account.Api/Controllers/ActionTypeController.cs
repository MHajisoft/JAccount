using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class ItemTypeController : GeneralTypeController
{
    public ItemTypeController(IGeneralTypeService service) : base(service, AccountConstant.ItemType)
    {
    }
}