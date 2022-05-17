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
        LtCustomers existingLtCustomer = null;
        
        if (entity.LtcGroupId is not null)
        {
            existingLtCustomer = await CheckForExistingLtCustomer(entity.LtcGroupId, entity.PlateNumber);    
        }
        
        if (entity.LtcGroupId is not 0 && entity.LtcGroupId is not null && existingLtCustomer is not null)
        {
            existingLtCustomer.LtcGroupId = entity.LtcGroupId; // import priskiria esamą LtcGroupId
            existingLtCustomer.LtCustomerName = entity.LtCustomerName;
            existingLtCustomer.PlateNumber = entity.PlateNumber;
            existingLtCustomer.Comment = entity.Comment;
            existingLtCustomer.IsInLot = entity.IsInLot;
            existingLtCustomer.ValidFrom = entity.ValidFrom; // import atnaujina datas
            
            // import atnaujina datas, jei naujos galiojančios ir kitokios. pateikus negaliojančią išvykimo datą, atnaujinimas nevykdomas.
            if ((entity.ValidTo >= DateTime.Today &&
                entity.ValidTo > existingLtCustomer.ValidTo) ||
                (entity.ValidTo >= DateTime.Today &&
                 entity.ValidTo < existingLtCustomer.ValidTo)) 
            {
                existingLtCustomer.ValidTo = entity.ValidTo;
            }
            existingLtCustomer.Enabled = entity.Enabled; 
            existingLtCustomer.LotPlaceTitle = entity.LotPlaceTitle;
            existingLtCustomer.AdditionalPlateNumbers = entity.AdditionalPlateNumbers;
            
            _context.Update(existingLtCustomer);
        } else if (entity.LtcGroupId is 0)
        {
            throw new ArgumentOutOfRangeException( $"{entity.PlateNumber}",
                " does not belong to any subscriber group (groupId 0). Please select another groupId number, to import this subscriber.");
        } 
        else // no LtcGroupId or no existing booking with such an id
        {
            entity.Deleted = false;
            entity.LtcGroupId = 2; // need to set a group id from request URL. 
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

    private async Task<LtCustomers> CheckForExistingLtCustomer(long? LtcGroupId, string plateNumber)
    {
        var existingLtCustomer = await _context.LtCustomers.SingleOrDefaultAsync(LTC =>
            LTC.Deleted == false && LTC.LtcGroupId == LtcGroupId && LTC.PlateNumber == plateNumber);
        
        return existingLtCustomer ?? null;
    }
}