using System.Collections;
using System.Linq.Expressions;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.EntityFrameworkCore;

namespace Account.Service.InfraStructure;

public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
{
    #region Constructor

    readonly DbContext _dbContext;
    readonly DbSet<T> _dbSet;

    public RepositoryBase(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    #endregion

    #region Load

    public async Task<T> Load(long id, bool needToCheckChangeHistory = false)
    {
        if (id == 0)
            //Prov: در اینجا و محل های مشابه امکان نمایش عنوان فارسی انتیتی وجود ندارد. زیرا عملکرد کلاس به صورت جنریک بوده و اگر بخواهیم به متد
            // نمایش عنوان فارسی دسترسی داشته باشیم باید امکان ایجاد کلاس و نیو کردن را هم اضافه کنیم که این کار باعث می شود تا برای همه
            // انتیتی ها کانستراکتور بدون پارامتر بسازیم. یا باید این کار را انجام دهیم و یا اینکه یک جدول مپ داشته باشیم و عناوین
            // انتیتی ها رو در آن نگهداری کرده و در این محل ها استفاده کنیم
            throw new Exception("LoadEntityByZeroIdIsNotValid");

        var result = await _dbSet.FindAsync(id);

        if (result == null)
            throw new Exception("ObjectNotFound");

        return result;
    }

    #endregion

    #region Search

    public async Task<List<T>> Search(Expression<Func<T, bool>>? expression)
    {
        return await (expression != null ? _dbSet.Where(expression).ToListAsync() : _dbSet.ToListAsync());
    }

    public async Task<int> SearchCount(Expression<Func<T, bool>>? expression)
    {
        return await (expression != null ? _dbSet.CountAsync(expression) : _dbSet.CountAsync());
        ;
    }

    #endregion

    #region Update

    public async Task<T> Update(T entity, CancellationToken cancellationToken = default)
    {
        if (entity.IsFresh())
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }
        else
        {
            //await UpdateAsync(entity, cancellationToken);
        }

        return entity;
    }

    public async Task<IEnumerable<T>> UpdateCollection(IEnumerable<T> entityCollection)
    {
        var result = new List<T>();

        foreach (var item in entityCollection)
        {
            await Update(item);
            result.Add(item);
        }

        return result;
    }

    public async Task<IEnumerable<T>> UpdateCollection(IList entityCollection)
    {
        var result = new List<T>();

        foreach (T item in entityCollection)
        {
            await Update(item);
            result.Add(item);
        }

        return result;
    }

    #endregion

    #region Delete

    public void Delete(T entity)
    {
        //EF Problem: بعد از ریمو، اساسیشن ها نال میشوند برای همین باید قبل از آن لاگ پراپرتی ها را انجام داد
        //LogUserActivity(item, UserActivityResource.Log_Delete);

        _dbSet.Remove(entity);
    }

    public async Task Delete(long id)
    {
        var entity = await Load(id);

        //EF Problem: بعد از ریمو، اساسیشن ها نال میشوند برای همین باید قبل از آن لاگ پراپرتی ها را انجام داد
        //LogUserActivity(item, UserActivityResource.Log_Delete);

        _dbSet.Remove(entity);
    }

    public async Task DeleteCollection(IEnumerable<long> idList)
    {
        foreach (var id in idList)
            await Delete(id);
    }

    public void DeleteCollection(IEnumerable<T> entityList)
    {
        foreach (var entity in entityList)
            Delete(entity);
    }

    #endregion

    #region SaveChanges

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }

    #endregion
}