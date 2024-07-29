using Account.Api.Base;
using Account.Common.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Authorization;

namespace Account.Api.Controllers;

[Authorize(Roles = nameof(AccountRoles.User))]
public class TransactionController(ITransactionService service) : EntityController<Transaction, TransactionDto>(service);