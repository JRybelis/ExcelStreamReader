using CoreData.Enums;

namespace CoreData;

public class BaseIdObject
{
    public long Skip { get; set; }
    public long Take { get; set; }
    public long CustomerId { get; set; }
    public long ComponentId { get; set; }
    public long PayTerminalId { get; set; }
    public long CompanyDetailsId { get; set; }
    public long StCustomerId { get; set; }
    public long TypeId { get; set; }
    public long GroupId { get; set; }
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Type { get; set; }
    public bool IsSuperAdmin { get; set; }
    public bool IsPaid { get; set; }
    public ValidatorStatus ValidatorStatus { get; set; }
    public PlateType PlateType { get; set; }
    public bool CalcLtcPayment { get; set; }
    public bool UseLevenshtein { get; set; }
    public int LevenshteinDistance { get; set; }
    public long PosId { get; set; }
    public string PlateNumber { get; set; }
    public long LocaleId { get; set; }
    public long UserFromId { get; set; }
    public long ParkingLogId { get; set; }
    public List<ComponentTypeEnum> ComponentTypes { get; set; }
    public List<string> ComponentKeys { get; set; }
    public string Title { get; set; }
    public bool SubscribersOnly { get; set; }
    public SystemType UserType { get; set; } = SystemType.Regular;
    public List<long> UserLots { get; set; } = new List<long>();
    public Dictionary<string, int> PermissionsNeedsCheck { get; set; } = new Dictionary<string, int>();
}