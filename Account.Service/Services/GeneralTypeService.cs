using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class GeneralTypeService : EntityService<GeneralType>, IGeneralTypeService
{
    public GeneralTypeService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }

    public override Task<GeneralType> Update(GeneralType entity)
    {
        throw new Exception("Category is required!");
    }

    public Task<GeneralType> Update(GeneralType entity, string category)
    {
        if (entity.IsFresh())
            entity.Category = category;
        else
        {
            if (entity.Category != category)
                throw new Exception("Category mismatched!");
        }

        return base.Update(entity);
    }
}