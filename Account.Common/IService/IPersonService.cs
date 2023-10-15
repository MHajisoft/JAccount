using Account.Common.Dto;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IPersonService : IEntityService<Person, PersonDto>
{
}