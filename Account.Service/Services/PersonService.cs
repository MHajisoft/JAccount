using Account.Common.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service.Services;

public class PersonService : EntityService<Person, PersonDto>, IPersonService
{
    public PersonService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }

    public override async Task<PersonDto> Update(PersonDto dto)
    {
        if (dto.RelativeId is null && dto.RelativeTypeId is not null || dto.RelativeId is not null && dto.RelativeTypeId is null)
            throw new Exception("نسبت و شخص مرتبط باید با هم مشخص شوند");
        
        if (dto.RelativeTypeId is not null)
        {
            var generalTypeRepository = AppServiceProvider.GetRequiredService<IRepository<GeneralType>>();
            var relativeType = await generalTypeRepository.Load(dto.RelativeTypeId.Value);

            if (!relativeType.Category.Equals(AccountConstant.RelativeType))
                throw new Exception("نوع نسبت اشتباه انتخاب شده است");
        }

        return await base.Update(dto);
    }
}