using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class GeneralTypeService : EntityService<GeneralType>, IGeneralTypeService
{
    public GeneralTypeService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }
}