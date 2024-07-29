using Account.Common.Dto;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface ITransactionService : IEntityService<Transaction, TransactionDto>
{
}