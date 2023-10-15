using Account.Api.Base;
using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class AttachmentController : EntityController<Attachment, AttachmentDto>
{
    public AttachmentController(IAttachmentService service) : base(service)
    {
    }
}