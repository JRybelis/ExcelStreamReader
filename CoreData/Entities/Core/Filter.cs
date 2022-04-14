namespace CoreData.Entities.Core;

public class Filter
{
    public string Column { get; set; }
    public string Operation { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public bool IgnoreUpper { get; set; }
    public bool IsAdvanceFilterColumn { get; set; }
    public override string ToString()
    {
        return $"Col:{Column} - Op:{Operation} - Type:{Type} - Val:{Value}";
    }
}