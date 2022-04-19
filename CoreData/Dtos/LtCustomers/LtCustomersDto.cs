using System.ComponentModel.DataAnnotations;

namespace CoreData.Dtos.LtCustomers;

public class LtCustomersDto
{
    public long? LtcGroupId { get; set; } // export - yes, import - no. importo metu, kuriamas naujas
    [MaxLength(331)] public string? LtCustomerName { get; set; }   
    [MaxLength(51)] public string? PlateNumber { get; set; } // reik išsitraukti LtCustomer instance toje grupėje (GetSingleByGroupAndPlateNumber()) ir sulyginti šį prop su dto/sumappintu entity. jei jau yra toks (deleted = false), atnaujinti. Jei nėra, create new LTC
    [MaxLength(724)]public string? AdditionalPlateNumbers { get; set; } // jei atvaizduoti, tai reik pasirūpinti filtravimu (daryt column nefiltruojamu)
    public bool? IsInLot { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool? Enabled { get; set; }
    [MaxLength(331)]public string? LotPlaceTitle { get; set; }
    [MaxLength(724)]public string? Comment { get; set; } // reik fronte(?) switch - isVisible
    public string? PincodeHash { get; set; } // kol kas nullable. neatvaizduoti
}