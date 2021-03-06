namespace ExcelStreamReader.Interfaces;

public interface IGenericRepository<T> /*where T : BaseDbObject<LtCustomers>*/
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task Upsert(T entity);
    Task Delete(int id);
    Task<T> GetByName(string itemName);
}