using System.Linq.Expressions;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Base;

public abstract class EntityService<TEntity, TDto> : ServiceBase, IEntityService<TEntity, TDto> where TEntity : BaseEntity, new() where TDto : BaseDto
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly DbSet<TEntity> DbSet;

    public EntityService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
        Repository = AppServiceProvider.GetRequiredService<IRepository<TEntity>>();
        DbSet = DbContext.Set<TEntity>();
    }

    public virtual async Task<TDto?> Get(long id)
    {
        return AppMapper.Map<TDto>(await Repository.Load(id));
    }

    public virtual async Task<List<TDto>> Search(Expression<Func<TDto, bool>>? expression)
    {
        var entityExpression = AppMapper.Map<Expression<Func<TEntity, bool>>>(expression);
        return AppMapper.Map<List<TDto>>(await Repository.Search(entityExpression));
    }

    public virtual async Task<TDto> Update(TDto dto)
    {
        var entity = dto.IsFresh() ? AppMapper.Map(dto, new TEntity()) : AppMapper.Map(dto, await Repository.Load(dto.Id));

        var result = await Repository.Update(entity);

        await Repository.SaveChanges();
        
        return AppMapper.Map<TDto>(result);
    }

    public virtual async Task Delete(long id)
    {
        await Repository.Delete(id);
        await Repository.SaveChanges();
    }
}