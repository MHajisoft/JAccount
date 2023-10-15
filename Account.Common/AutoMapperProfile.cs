using Account.Common.Dto;
using Account.Common.Entity;
using AutoMapper;

namespace Account.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Attachment, AttachmentDto>().ReverseMap();
        CreateMap<GeneralType, GeneralTypeDto>().ReverseMap();
        CreateMap<Transaction, TransactionDto>().ReverseMap();
    }
}