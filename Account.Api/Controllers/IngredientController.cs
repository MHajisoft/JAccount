using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class IngredientController : GeneralTypeController
{
    public IngredientController(IGeneralTypeService service) : base(service, AccountConstant.Ingredient)
    {
    }
}