namespace CoreData.Interfaces;

public interface IDataObject : ITotalCount
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
    
}