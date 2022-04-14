using System.ComponentModel.DataAnnotations;

namespace CoreData.Dtos.LtCustomers;

public class LtCustomersDto
{
    public long Id { get; set; } // export - yes, import - no. importo metu, kuriamas naujas
    [MaxLength(221)] public string Name { get; set; }
    [MaxLength(124)] public string PlateNumber { get; set; }
    public bool IsInLot { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool Enabled { get; set; }
    [MaxLength(254)]public string LotPlaceTitle { get; set; }
}