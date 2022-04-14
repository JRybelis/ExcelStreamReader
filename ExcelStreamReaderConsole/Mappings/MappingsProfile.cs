using AutoMapper;
using CoreData.Dtos.LtCustomers;
using CoreData.Entities.LtCustomers;

namespace ExcelStreamReaderConsole.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<LtCustomersDto, LtCustomers>().ReverseMap();
    }
}