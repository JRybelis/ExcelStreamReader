using AutoMapper;
using CoreData.Dtos.LtCustomers;
using CoreData.Entities.LtCustomers;
using ExcelStreamReader.Interfaces;
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

    /*[HttpGet]
    public override async Task<IEnumerable<LtCustomersDto>> GetAll()
    {
        var entities = await _repository.GetAll();
        var dtos = _mapper.Map<IEnumerable<LtCustomersDto>>(entities);
        return dtos;
    }

    [HttpGet("{id}")]
    public async Task<LtCustomers> GetById(int id)
    {
        var entity = await _repository.GetById(id);
        return _mapper.Map<LtCustomers>(entity);
    }

    [HttpPost]
    public async Task Upsert(LtCustomersDto dto)
    {
        var entity = _mapper.Map<LtCustomers>(dto);
        await _repository.Upsert(entity);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }*/
    
}