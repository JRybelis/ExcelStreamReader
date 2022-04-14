using IDataObject = CoreData.Interfaces.IDataObject;

namespace CoreData;

public abstract class BaseDbObject<T> where T : IDataObject, new()
{
    private static readonly Lazy<T> Instance = new Lazy<T>(() => new T());
    private static T TestInstance = default;

    public static T I => TestInstance == null ? Instance.Value : TestInstance;
}