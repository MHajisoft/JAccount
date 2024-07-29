using System.Linq.Expressions;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> Load(long id);

    Task<List<T>> Search(Expression<Func<T, bool>>? expression);
    Task<int> SearchCount(Expression<Func<T, bool>>? expression);

    Task<T> Update(T entity, CancellationToken cancellationToken = default);


    Task Delete(long id);

    void Delete(T entity);

    Task SaveChanges();
}