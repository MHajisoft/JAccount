using Account.Api.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers;

public abstract class GeneralTypeController : EntityController<GeneralType, GeneralTypeDto>
{
    protected readonly string Category;

    protected GeneralTypeController(IGeneralTypeService service, string category) : base(service)
    {
        Category = category;
    }

    [HttpGet]
    public override async Task<List<GeneralTypeDto>> GetAll()
    {
        return await Service.Search(x => x.Category == Category);
    }

    [HttpGet]
    public override async Task<GeneralTypeDto?> Load(long id)
    {
        return (await Service.Search(x => x.Id == id && x.Category == Category)).SingleOrDefault();
    }

    [HttpPost]
    public override Task<GeneralTypeDto> Update([FromBody]GeneralTypeDto dto)
    {
        dto.Category = Category;

        return ((IGeneralTypeService)Service).Update(dto, Category);
    }
}