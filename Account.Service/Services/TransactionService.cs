using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class TransactionService : EntityService<Transaction>, ITransactionService
{
    public TransactionService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }
}