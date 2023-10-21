using Account.Common.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Services;

public class TransactionService : EntityService<Transaction, TransactionDto>, ITransactionService
{
    public TransactionService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }

    public async Task<TransactionDto> Update(TransactionDto dto)
    {
        var generalTypeRepository = AppServiceProvider.GetRequiredService<IRepository<GeneralType>>();
        var personRepository = AppServiceProvider.GetRequiredService<IRepository<Person>>();

        if (await personRepository.SearchCount(x => x.Id == dto.PersonId) == 0)
            throw new Exception("شخص انتخاب شده معتبر نمی باشد");

        if (!(await generalTypeRepository.Load(dto.AccountTypeId)).Category.Equals(AccountConstant.AccountType))
            throw new Exception("نحوه دریافت و هزینه معتبر نمی باشد");

        if (!(await generalTypeRepository.Load(dto.CostTypeId)).Category.Equals(AccountConstant.CostType))
            throw new Exception("نوع هزینه معتبر نمی باشد");

        if (dto.ItemTypeId is not null && !(await generalTypeRepository.Load(dto.ItemTypeId.Value)).Category.Equals(AccountConstant.ItemType))
            throw new Exception("عملکرد انتخابی معتبر نمی باشد");

        return await base.Update(dto);
    }
}