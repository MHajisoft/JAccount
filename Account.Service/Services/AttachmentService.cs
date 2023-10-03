using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class AttachmentService : EntityService<Attachment>, IAttachmentService
{
    public AttachmentService(IServiceProvider appServiceProvider) : base(appServiceProvider)
    {
    }
}