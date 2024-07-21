using Account.Common.Base;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class IngredientController(IGeneralTypeService service)
    : GeneralTypeController(service, AccountConstant.Ingredient);