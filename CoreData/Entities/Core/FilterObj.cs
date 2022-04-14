using System.Text;

namespace CoreData.Entities.Core;

public class FilterObj
{
    public string Match { get; set; }
    public List<Filter> Columns { get; set; } = new();

    public override string ToString()
    {
        var str = new StringBuilder();
        foreach (var filter in Columns)
        {
            str.AppendFormat(" f: {0} ", filter);
        }

        return $"Match: {Match} - Cols: {str}";
    }
}