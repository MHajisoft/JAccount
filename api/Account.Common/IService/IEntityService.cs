using System.Linq.Expressions;
using Account.Common.Dto;
using Account.Common.Entity;

namespace Account.Common.IService;

public interface IEntityService<TEntity, TDto> : IServiceBase where TEntity : BaseEntity where TDto : BaseDto
{
    Task<TDto?> Get(long id);
    Task<List<TDto>> Search(Expression<Func<TDto, bool>>? expression = null);

    Task<TDto> Update(TDto dto);

    Task Delete(long id);
}