using Account.Common.Dto;
using Account.Common.Entity;
using Account.Common.IService;
using Account.Service.Base;

namespace Account.Service.Services;

public class AttachmentService(IServiceProvider appServiceProvider)
    : EntityService<Attachment, AttachmentDto>(appServiceProvider), IAttachmentService;