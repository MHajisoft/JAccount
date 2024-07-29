using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Base;

public abstract class EntityController<TEntity, TDto>(IEntityService<TEntity, TDto> service) : BaseController
    where TEntity : BaseEntity, new()
    where TDto : BaseDto
{
    protected readonly IEntityService<TEntity, TDto> Service = service;

    [HttpGet]
    public virtual async Task<List<TDto>> GetAll()
    {
        return await Service.Search();
    }

    [HttpGet]
    public virtual async Task<TDto?> Load(long id)
    {
        return await Service.Get(id);
    }

    [HttpPost]
    public virtual async Task<TDto> Update(TDto dto)
    {
        return await Service.Update(dto);
    }

    [HttpDelete]
    public virtual async Task Delete(long id)
    {
        await Service.Delete(id);
    }
}