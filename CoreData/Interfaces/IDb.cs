using CoreData.Entities.Core;

namespace CoreData.Interfaces;

public interface IDb<out T>
{
    T GetSingleById(long id);
    T GetByGrid(long grid, IDatabase db);
    
    /// <summary>
    /// Returns List of object 
    /// </summary>
    /// <param name="filter">array of filter objects</param>
    /// <param name="sort"></param>
    /// <param name="isSuperAdmin"></param>
    /// <param name="id">0-skip,1-take,2-customerId..., other required ids</param>
    IEnumerable<T> GetAll(FilterObj filter, string sort, bool isSuperAdmin, BaseIdObject id);

    /// <summary>
    /// Returns row count
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="isSuperAdmin"></param>
    /// <param name="id"></param>
    long GetAllCount(FilterObj filter, bool isSuperAdmin, BaseIdObject id);

    void Create(IDatabase db = null); //npoco - pakeist
    void Update(IDatabase db = null);
    long Delete(IDatabase db = null);
}