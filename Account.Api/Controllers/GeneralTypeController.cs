using Account.Api.Base;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers;

public abstract class GeneralTypeController : EntityController<GeneralType>
{
    protected readonly string Category;

    protected GeneralTypeController(IGeneralTypeService service, string category) : base(service)
    {
        Category = category;
    }

    [HttpGet]
    public override async Task<List<GeneralType>> GetAll()
    {
        return await Service.Search(x => x.Category == Category);
    }

    [HttpGet]
    public override async Task<GeneralType?> Load(long id)
    {
        return (await Service.Search(x => x.Id == id && x.Category == Category)).SingleOrDefault();
    }

    [HttpPost]
    public override Task<GeneralType?> Update(GeneralType entity)
    {
        entity.Category = Category;

        return base.Update(entity);
    }
}