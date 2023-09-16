using System.Linq.Expressions;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Load(long id, bool needToCheckChangeHistory = false);

    Task<List<T>> Search(Expression<Func<T, bool>>? expression);
    Task<int> SearchCount(Expression<Func<T, bool>>? expression);

    Task<T> Update(T entity, CancellationToken cancellationToken = default);


    Task Delete(long id);
    Task DeleteCollection(IEnumerable<long> idList);

    void Delete(T entity);
    void DeleteCollection(IEnumerable<T> entityList);

    Task SaveChanges();
}