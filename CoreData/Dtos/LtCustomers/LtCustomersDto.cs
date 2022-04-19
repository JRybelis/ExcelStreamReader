using System.ComponentModel.DataAnnotations;

namespace CoreData.Dtos.LtCustomers;

public class LtCustomersDto
{
    public long Id { get; set; } // export - yes, import - no. importo metu, kuriamas naujas
    [MaxLength(331)] public string LtCustomerName { get; set; }
    [MaxLength(51)] public string PlateNumber { get; set; }
    [MaxLength(724)]public string? AdditionalPlateNumbers { get; set; }
    public bool IsInLot { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool Enabled { get; set; }
    [MaxLength(331)]public string LotPlaceTitle { get; set; }
    [MaxLength(724)]public string? Comment { get; set; }
}