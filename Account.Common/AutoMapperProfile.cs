using Account.Common.Dto;
using Account.Common.Entity;
using AutoMapper;

namespace Account.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();

        CreateMap<Attachment, AttachmentDto>();
        CreateMap<AttachmentDto, Attachment>();
        
        CreateMap<GeneralType, GeneralTypeDto>();
        CreateMap<GeneralTypeDto, GeneralType>();
        
        CreateMap<Transaction, TransactionDto>();
        CreateMap<TransactionDto, Transaction>();
    }
}