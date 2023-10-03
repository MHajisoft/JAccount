using Account.Common.Entity;

namespace Account.Common.IService;

public interface IEntityService<T> : IServiceBase where T : BaseEntity
{
    Task<T?> Get(long id);

    Task<T> Update(T entity);
    Task<List<T>> UpdateCollection(List<T> list);

    Task Delete(long id);
    void Delete(T entity);
}