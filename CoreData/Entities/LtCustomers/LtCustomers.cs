using CoreData.Enums;
using CoreData.Interfaces;

namespace CoreData.Entities.LtCustomers;

public class LtCustomers : IDataObject
{
    public long? Id { get; set; } // kol kas nullable.
    public bool? ArchiveRow { get; } // kol kas nullable.
    public bool? Deleted { get; set; } // kol kas nullable.
    public long? UsersLogId { get; set; } // kol kas nullable.
    public long? Grid { get; set; } // kol kas nullable.
    public bool? GridSupported { get; } // kol kas nullable.
    public bool? SyncEnabled { get; } // kol kas nullable.
    public string? PlateNumber { get; set; } // kol kas nullable.
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string? LtCustomerName { get; set; } // kol kas nullable.
    public long? LtcGroupId { get; set; } // kol kas nullable.
    public string? Comment { get; set; } // kol kas nullable.
    public bool? Enabled { get; set; }
    public string? PincodeHash { get; set; } // kol kas nullable.
    public long? CustomerId { get; set; } // kol kas nullable.
    public long? LotPlaceId { get; set; } // kol kas nullable.
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Car;
    public string? LtcGroupName { get; set; } // kol kas nullable.
    public string? CustomerName { get; set; } // kol kas nullable.
    public int? CompanySlots { get; private set; }
    public int? PriceRateId { get; private set; } // kol kas nullable.
    public int? CompanyDetailsId { get; set; } // kol kas nullable.
    public bool? IsLtCustomerAdditionalPlate { get; set; } // kol kas nullable.
    public string? LotPlaceTitle { get; set; }
    public string? AdditionalPlateNumbers { get; set; } // kol kas nullable
    public PaymentOptionsEnum? PaymentOption { get; set; } // kol kas nullable.
    public bool? IsInLot { get; set; }
    public string? VehicleTypeTitle { get; set; } // kol kas nullable.
    public UsersLogActionEnum? UsersLogActionId { get; set; } // kol kas nullable.
    
    /*public void Create(IDatabase db = default(IDatabase))
    {
        throw new NotImplementedException();
    }

    public void Update(IDatabase db = default(IDatabase))
    {
        throw new NotImplementedException();
    }

    public long Delete(IDatabase db = default(IDatabase))
    {
        throw new NotImplementedException();
    }

    public long SyncCreate(SyncMode mode, IDatabase db)
    {
        throw new NotImplementedException();
    }

    public long GetGrid(IDatabase db)
    {
        throw new NotImplementedException();
    }*/
    public long? TotalCount { get; set; }
}