using CoreData.Enums;
using CoreData.Interfaces;

namespace CoreData.Entities.LtCustomers;

public class LtCustomers : IDataObject
{
    public long Id { get; set; }
    public bool ArchiveRow { get; }
    public bool Deleted { get; set; }
    public long UsersLogId { get; set; }
    public long Grid { get; set; }
    public bool GridSupported { get; }
    public bool SyncEnabled { get; }
    public string PlateNumber { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
    public string LtCustomerName { get; set; }
    public long LtcGroupId { get; set; }
    public string Comment { get; set; }
    public bool Enabled { get; set; }
    public string PincodeHash { get; set; }
    public long CustomerId { get; set; }
    public long LotPlaceId { get; set; }
    public VehicleTypeEnum VehicleType { get; set; } = VehicleTypeEnum.Car;
    public string LtcGroupName { get; set; }
    public string CustomerName { get; set; }
    public int? CompanySlots { get; private set; }
    public int PriceRateId { get; private set; }
    public int CompanyDetailsId { get; set; }
    public bool IsLtCustomerAdditionalPlate { get; set; }
    public string LotPlaceTitle { get; set; }
    public string AdditionalPlateNumbers { get; set; }
    public PaymentOptionsEnum PaymentOption { get; set; }
    public bool IsInLot { get; set; }
    public string VehicleTypeTitle { get; set; }
    public UsersLogActionEnum UsersLogActionId { get; set; }
    
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
    public long TotalCount { get; set; }
}