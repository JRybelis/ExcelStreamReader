using AutoMapper;
using CoreData.Dtos.LtCustomers;
using CoreData.Entities.LtCustomers;
using ExcelStreamReader.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExcelStreamReader.Controllers;

[ApiController]
[Route("[controller]")]
public class GenericControllerBase<TDto, TEntity> : ControllerBase
    where TDto : LtCustomersDto where TEntity : LtCustomers
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TEntity> _repository;

    public GenericControllerBase(IMapper mapper, IGenericRepository<TEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public virtual async Task<IEnumerable<TDto>> GetAll()
    {
        var entities = await _repository.GetAll();
        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    [HttpGet("{id}")]
    public async Task<TDto> GetById(int id)
    {
        var entity = await _repository.GetById(id);
        return _mapper.Map<TDto>(entity);
    }

    [HttpPost]
    public async Task Upsert(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _repository.Upsert(entity);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}
