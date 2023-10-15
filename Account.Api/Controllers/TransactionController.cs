using Account.Api.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class TransactionController : EntityController<Transaction, TransactionDto>
{
    public TransactionController(ITransactionService service) : base(service)
    {
    }
}