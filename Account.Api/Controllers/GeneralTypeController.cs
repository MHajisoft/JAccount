using Account.Api.Base;
using Account.Common.Entity;
using Account.Common.IService;

namespace Account.Api.Controllers;

public abstract class GeneralTypeController : EntityController<GeneralType>
{
    protected string Category;
    protected GeneralTypeController(IGeneralTypeService service, string category) : base(service)
    {
        Category = category;
    }
}