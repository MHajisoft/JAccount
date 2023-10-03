using Account.Common.IService;
using Account.Service.InfraStructure;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Base;

public abstract class ServiceBase : IServiceBase
{
    #region Constructor

    protected readonly IServiceProvider AppServiceProvider;
    protected readonly AppDbContext DbContext;
    protected readonly IMapper AppMapper;

    protected ServiceBase(IServiceProvider appServiceProvider)
    {
        AppServiceProvider = appServiceProvider;
        AppMapper = AppServiceProvider.GetRequiredService<IMapper>();
        DbContext = AppServiceProvider.GetRequiredService<AppDbContext>();
    }

    #endregion

    #region ExecuteCommand

    protected async Task<TResult> ExecuteCommand<TResult>(Func<Task<TResult>> command) where TResult : class
    {
        try
        {
            await DbContext.Database.BeginTransactionAsync();

            var entity = await command.Invoke();

            await DbContext.Database.CommitTransactionAsync();

            return entity;
        }
        catch (Exception ex)
        {
            try
            {
                await DbContext.Database.RollbackTransactionAsync();
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