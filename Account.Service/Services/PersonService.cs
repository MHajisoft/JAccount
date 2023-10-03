using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class PersonService : EntityService<Person>, IPersonService
{
    public PersonService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }
}