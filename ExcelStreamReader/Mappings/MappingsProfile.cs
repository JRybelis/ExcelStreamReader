using AutoMapper;
using CoreData.Dtos.LtCustomers;
using CoreData.Entities.LtCustomers;

namespace ExcelStreamReader.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile()
    {
        CreateMap<LtCustomersDto, LtCustomers>().ReverseMap();
    }
}