using Account.Api.Base;
using Account.Common.Entity;
using Account.Common.IService;

namespace Account.Api.Controllers;

public class AttachmentController : EntityController<Attachment>
{
    public AttachmentController(IAttachmentService service) : base(service)
    {
    }
}