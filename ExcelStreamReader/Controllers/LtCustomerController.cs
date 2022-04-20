using AutoMapper;
using CoreData.Dtos.LtCustomers;
using CoreData.Entities.LtCustomers;
using ExcelStreamReader.Interfaces;
using ExcelStreamReader.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExcelStreamReader.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class LtCustomerController : GenericControllerBase<LtCustomersDto, LtCustomers>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<LtCustomers> _repository;

    public LtCustomerController(IGenericRepository<LtCustomers> repository, IMapper mapper) : base(mapper, repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task Import(string documentLocation)
    {
        var listLtCustomersDtos = LtCustomersService.ReadExcelData(documentLocation).Result;

        foreach (var entity in listLtCustomersDtos.SelectMany(ltCustomersDtos => ltCustomersDtos.Select(ltCustomersDto => _mapper.Map<LtCustomers>(ltCustomersDto))))
        {
            await _repository.Upsert(entity);
        }
    }
}