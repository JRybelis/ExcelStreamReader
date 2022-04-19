namespace CoreData.Interfaces;

public interface IDataObject : ITotalCount
{
    /// <summary>
    /// Local record ID (primary key)
    /// </summary>
    public long? Id { get; set; }
    bool? ArchiveRow { get; } // kol kas nullable.
    public bool? Deleted { get; set; } // kol kas nullable.
    public long? UsersLogId { get; set; } // kol kas nullable.
    /// <summary>
    /// Global Record ID
    /// </summary>
    long? Grid { get; set; } // kol kas nullable.
    /// <summary>
    /// Is the DB object fully supported in the DB table and its class code?
    /// Default: false.
    /// </summary>
    bool? GridSupported { get; } // kol kas nullable.
    /// <summary>
    /// Should changes to the object be updated in the sync_queue table?
    /// </summary>
    bool? SyncEnabled { get; } // kol kas nullable.
    
}