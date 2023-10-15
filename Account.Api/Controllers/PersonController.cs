using Account.Api.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class PersonController : EntityController<Person, PersonDto>
{
    public PersonController(IPersonService service) : base(service)
    {
    }
}