using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.InfraStructure;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Base;

public abstract class ServiceBase<TEntity> : IServiceBase
    where TEntity : BaseEntity, new()
{
    #region Constructor

    protected readonly IServiceProvider AppServiceProvider;
    protected IRepository<TEntity> Repository;
    protected readonly AppDbContext _dbContext;
    protected readonly IMapper AppMapper;

    public ServiceBase(IServiceProvider appServiceProvider)
    {
        AppServiceProvider = appServiceProvider;
        Repository = AppServiceProvider.GetRequiredService<IRepository<TEntity>>();
        AppMapper = AppServiceProvider.GetRequiredService<IMapper>();
        _dbContext = AppServiceProvider.GetRequiredService<AppDbContext>();
    }

    #endregion

    #region ExecuteCommand

    protected async Task<TResult> ExecuteCommand<TResult>(Func<Task<TResult>> command) where TResult : class
    {
        try
        {
            await _dbContext.Database.BeginTransactionAsync();

            var entity = await command.Invoke();

            await _dbContext.Database.CommitTransactionAsync();

            return entity;
        }
        catch (Exception ex)
        {
            try
            {
                await _dbContext.Database.RollbackTransactionAsync();
            }
            catch (Exception rollbackEx)
            {
                Serilog.Log.Error(rollbackEx, "");
            }

            throw;
        }
    }

    #endregion
}