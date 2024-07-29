using Account.Common.Dto;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IGeneralTypeService : IEntityService<GeneralType, GeneralTypeDto>
{
    Task<GeneralTypeDto> Update(GeneralTypeDto dto, string category);
}