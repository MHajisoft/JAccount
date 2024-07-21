using Account.Common.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Services;

public class TransactionService(IServiceProvider appServiceProvider)
    : EntityService<Transaction, TransactionDto>(appServiceProvider), ITransactionService
{
    public override async Task<TransactionDto> Update(TransactionDto dto)
    {
        var generalTypeRepository = AppServiceProvider.GetRequiredService<IRepository<GeneralType>>();
        var personRepository = AppServiceProvider.GetRequiredService<IRepository<Person>>();

        if (await personRepository.SearchCount(x => x.Id == dto.PersonId) == 0)
            throw new Exception("شخص انتخاب شده معتبر نمی باشد");

        if (!(await generalTypeRepository.Load(dto.AccountId)).Category.Equals(AccountConstant.Account))
            throw new Exception("نحوه دریافت و هزینه معتبر نمی باشد");

        if (!(await generalTypeRepository.Load(dto.CostId)).Category.Equals(AccountConstant.Cost))
            throw new Exception("نوع هزینه معتبر نمی باشد");

        if (dto.ReasonId is not null && !(await generalTypeRepository.Load(dto.ReasonId.Value)).Category.Equals(AccountConstant.Reason))
            throw new Exception("عملکرد انتخابی معتبر نمی باشد");

        return await base.Update(dto);
    }
}