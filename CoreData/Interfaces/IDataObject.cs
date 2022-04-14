using ExcelStreamReaderConsole;

namespace CoreData.Interfaces;

public interface IDataObject
{
    /// <summary>
    /// Local record ID (primary key)
    /// </summary>
    public long Id { get; set; }
    bool ArchiveRow { get; }
    public bool Deleted { get; set; }
    public long UsersLogId { get; set; }
    /// <summary>
    /// Global Record ID
    /// </summary>
    long Grid { get; set; }
    /// <summary>
    /// Is the DB object fully supported in the DB table and its class code?
    /// Default: false.
    /// </summary>
    bool GridSupported { get; }
    /// <summary>
    /// Should changes to the object be updated in the sync_queue table?
    /// </summary>
    bool SyncEnabled { get; }
    
    void Create(IDatabase db = null);
    void Update(IDatabase db = null);
    long Delete(IDatabase db = null);
    
    /// <summary>
    /// Synchronise Create operation.
    /// </summary>
    /// <returns>0 or GRID value, which needs to be returned to the remote server.</returns>
    long SyncCreate(SyncMode mode, IDatabase db);
    
    /// <summary>
    /// Takes the GRID value from the DB, not from Grid property.
    /// </summary>
    long GetGrid(IDatabase db);
}