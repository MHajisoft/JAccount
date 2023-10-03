using Account.Common.Entity;

namespace Account.Common.IService;

public interface IGeneralTypeService : IEntityService<GeneralType>
{
    Task<GeneralType> Update(GeneralType entity, string category);
}