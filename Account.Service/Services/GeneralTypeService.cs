using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class GeneralTypeService : EntityService<GeneralType, GeneralTypeDto>, IGeneralTypeService
{
    public GeneralTypeService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }

    public override Task<GeneralTypeDto> Update(GeneralTypeDto entity)
    {
        throw new Exception("Category is required!");
    }

    public Task<GeneralTypeDto> Update(GeneralTypeDto dto, string category)
    {
        if (dto.IsFresh())
            dto.Category = category;
        else
        {
            if (dto.Category != category)
                throw new Exception("Category mismatched!");
        }

        return base.Update(dto);
    }
}