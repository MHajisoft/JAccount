using System.Linq.Expressions;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Base;

public abstract class EntityService<TEntity> : ServiceBase, IEntityService<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly IRepository<TEntity> Repository;
    protected readonly DbSet<TEntity> DbSet;

    public EntityService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
        Repository = AppServiceProvider.GetRequiredService<IRepository<TEntity>>();
        DbSet = DbContext.Set<TEntity>();
    }

    public virtual async Task<TEntity?> Get(long id)
    {
        return await Repository.Load(id);
    }

    public virtual async Task<List<TEntity>> Search(Expression<Func<TEntity, bool>>? expression)
    {
        return await Repository.Search(expression);
    }
    
    public virtual async Task<TEntity> Update(TEntity entity)
    {
        return await Repository.Update(entity);
    }

    public Task<List<TEntity>> UpdateCollection(List<TEntity> list)
    {
        throw new NotImplementedException();
    }

    public virtual async Task Delete(long id)
    {
        await Repository.Delete(id);
    }

    public void Delete(TEntity entity)
    {
        Repository.Delete(entity);
    }
}