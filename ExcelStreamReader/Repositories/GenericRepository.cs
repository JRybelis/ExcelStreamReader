using CoreData.Entities.LtCustomers;
using ExcelStreamReader.Data;
using ExcelStreamReader.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExcelStreamReader.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : LtCustomers
{
    private readonly DataContext _context;

    public GenericRepository(DataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return entity;
    }

    public async Task Upsert(T entity)
    {
        if (entity.Id is not 0)
        {
            _context.Update(entity);
        } else
        {
            _context.Add(entity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        if (entity is not null)
        {
            _context.Remove(entity);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByName(string itemName)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.LtCustomerName == itemName);

        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return entity;
    }

    public Task Import(T entity, int quantity) // same as upsert? 
    {
        throw new NotImplementedException();
    }
}