namespace ExcelStreamReaderConsole;

public class LtCustomers
{
    public long Id { get; set; }
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
}