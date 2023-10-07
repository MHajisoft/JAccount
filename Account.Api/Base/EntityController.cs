using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Base;

public abstract class EntityController<TEntity> : BaseController where TEntity : BaseEntity, new()
{
    protected readonly IEntityService<TEntity> Service;

    public EntityController(IEntityService<TEntity> service)
    {
        Service = service;
    }

    [HttpGet]
    public virtual async Task<List<TEntity>> GetAll()
    {
        return await Service.Search();
    }

    [HttpGet]
    public virtual async Task<TEntity?> Load(long id)
    {
        return await Service.Get(id);
    }

    [HttpPost]
    public virtual async Task<TEntity?> Update(TEntity entity)
    {
        return await Service.Update(entity);
    }

    [HttpDelete]
    public virtual async Task Delete(long id)
    {
        await Service.Delete(id);
    }
}