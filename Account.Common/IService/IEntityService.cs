using System.Linq.Expressions;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IEntityService<TEntity> : IServiceBase where TEntity : BaseEntity
{
    Task<TEntity?> Get(long id);
    Task<List<TEntity>> Search(Expression<Func<TEntity, bool>>? expression = null);

    Task<TEntity> Update(TEntity entity);
    Task<List<TEntity>> UpdateCollection(List<TEntity> list);

    Task Delete(long id);
    void Delete(TEntity entity);
}