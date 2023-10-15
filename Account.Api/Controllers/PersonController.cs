using Account.Api.Base;
using Account.Common.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Microsoft.AspNetCore.Authorization;

namespace Account.Api.Controllers;

[Authorize(Roles = nameof(AccountRoles.User))]
public class PersonController : EntityController<Person, PersonDto>
{
    public PersonController(IPersonService service) : base(service)
    {
    }
}