using pbr = global::Google.Protobuf.Reflection;
namespace ExcelStreamReaderConsole;

public enum VehicleTypeEnum
{
    Motorcycle = 1,
    Car = 2,
    Bus = 3,
    Truck = 4,
    Camper = 5,
    LongBus = 6,
    HeavyTruck = 7,
    Tractor = 8,
    Trailer = 9,
    Undefined = 10000,
    CarWithTrailer = 10009,
    MaritimeMuseum = 10011,
    Government = 10012,
    SpecialServices = 10013,
    Disabled = 10014,
    TouristAgreement = 10015,
    NotOpened = 10016,
    Fault = 10017,
    ElectricCar = 10018
}

public enum PaymentOptionsEnum
{
    Bill = 1,
    Pos = 2,
    Any = 3
}

public enum UsersLogActionEnum
{
    Unknown = 0,
    LoginOK = 1,
    LoginDenied = 2,
    Logout = 3,
    InsertRow = 4,
    UpdateRow = 5,
    DeleteRow = 6,
    CoinBalanceSettingsChanged = 7,
    AllowedDenomsUnder10Changed = 8,
    AllowedDenomsUnder20Changed = 9,
    AllowedDenomsOver20Changed = 10,
    AdminAposPasswordChanged = 11,
    UserAposIntervalsChanged = 12,
    VatChanged = 13,
    PriceRateParamsChanged = 14,
    PriceRateInfoChanged = 15,
    ReceiptHeaderChanged = 16,
    NotificationEmailsChanged = 17,
    RepositorySettingsChanged = 18,
    FinancialQueryPerformed = 19,
    FinancialQueryExported = 20,
    PaymentReceiptRemotePrinted = 21,
    WithdrawalReceiptRemotePrinted = 22,
    DepositReceiptRemotePrinted = 23,
    StateReceiptRemotePrinted = 24,
    PaymentRestrictionsChanged = 25,
    StateReceiptLocalPrinted = 26,
    DepositReceiptLocalPrinted = 27,
    WithdrawalReceiptLocalPrinted = 28,
    PaymentLocalRemotePrinted = 30,
    BalanceReceiptLocalPrinted = 31,
    PaymentLocalLocalPrinted = 32,
    BalanceReceiptRemotePrinted = 33,
    GetListError = 34,
    GetSingleError = 35,
    ImpersonatorLoginOk = 36,
    ImpersonatorLoginFailed = 37,
    EmailSendError = 38,
    ExportFailed = 39,
    ExportUITable = 40,
    UserPasswordChanged = 41,
    GeneralSettingsChanged = 42,
    UserAposTextsChanged = 43,
    DispenseErrorLocalPrinted = 44,
    DispenseErrorRemotePrinted = 45,
    CameraSettingsUpdate = 46,
    RestartError = 47,
    Restart = 48,
    UpdateLaunched = 49,
    UptModuleCommandSend = 50,
    TriggerBtnClicked = 51,
    OpenBarrierMsgSend = 52,
    PlateMsgSend = 53,
    PlateAndOpenBarrierMsgSend = 54,
    KeepBarrierOpenMsgSend = 55,
    KeepBarrierClosedMsgSend = 56,
    KeepBarrierAutoMsgSend = 57,
    InsertFailed = 58,
    UpdateFailed = 59,
    DeleteFailed = 60,
    SynchronizationDeleteRow = 61,
    SynchronizationInsertRow = 62
}

public enum PlateType
{
    // id linked with table plate_type
    Subscriber = 1,
    Online = 2,
    ShortTerm = 3,
    Unreadable = 4,
    Unknown = 5,
    BlackListed = 6,
    Rfid = 7,
    Domophone = 8
}

public enum ValidatorStatus
{
    NotAvail = 1,       // ne LTC ir ne STC numeriams
    Ok = 2,             // galiojantiems LTC ir sumokejusiems STC
    OkAntipassOff = 3,  // galiojantiems LTC ir sumokejusiems STC, pasibaigus ANTIPASS periodui arba ExitTimeM periodui. 
                        // LTC klientui isvaziuojant kuriamas occupation irasas be entry_dt
    Antipass = 4,       // galiojantiems LTC ir sumokejusiems STC
    LotFull = 5,        // LTC ir STC
    OverSlotLimit = 6,  // LTC (ateityje gal ir STC)
    OverTimeLimit = 7,  // pasibaigusiems LTC ir nespejusiems isvaziuoti STC
    Disabled = 8,       // active=false LTC arba STC bandymas isvaziuoti neturint ivaziavimo pasibaigus ankstesniam isvaziavimo periodui
    Free = 9,           // STC, kai galioja nemokamas pradinis stovejimo laikas
    NoCharge = 10,      // STC, jei pagal tarifa stovejo nemokamomis valandomis
    NotPaid = 11,       // STC
    StrictBlock = 12,   // nezinomiems arba nenuskaitomiems numeriams
    MustStay = 13,      // jei STC neprastovejo minimalaus privalomo laiko aiksteleje
    MustCall = 14,      // neaktyvus STC klientas, is kurio laukiama skambucio i GSM moduli
    RestrictedLot = 15, // LTC kliento imonei nepriskirtos vietos aiksteleje
    OkRepeating = 16,    // LTC kliento ivaziavimas/isvaziavimas dar nepasibaigus ANTIPASS periodui
    OkAdditionalSlot = 17, // LTC kliento ivaziavimas/isvaziavimas jei priskirtas papildomų vietų skaičius 
    OkCrossing = 18,       //LTC kai įvažiuoja į pagrindinę aikštelę su sub aišktelėm
    ExitTimeExpired = 19, // Viršytas išvažiavimo laikas po apmėjimo kasoje,
    MustWait = 20,        // How long STC will have to wait after exit before they can enter the same parking lot again.
    OkCrossingRepeating = 21,  //LTC kai įvažiuoja į pagrindinę aikštelę su sub aišktelėm, ir įvykis kartojasi
    MustTakeTicket = 22,  // neaktyvus klientas, kuris turi paimti bilietą ar kvitą iš terminalo
    BackoutEvent = 23,  // Suveikus BackoutModule, siunciama informacija useriui, kad ivyko backout ivykis
    ManualCheck = 24, //naudojamas kai reikalaujama patikrinti automobilį
    CustomNotification = 25, //Notification modulyje yra {custom_msg} tagas, kurį parodys iš vertimų nustačius šitą statusą, ICustomNotificationText
    ApprovalRequiredEvent = 26, // special case for validation when user comment on parking log is required
    BookingExitWithViolation = 27 // išvažiavimas pasibaigus rezervacijos laikotarpiui
}

public enum ComponentTypeEnum
{
    Lot = 1,
    Terminal = 2,
    /// <summary>
    /// Module, ScheduledTask, etc.
    /// </summary>
    Device = 4,
    Service = 5,
    Customer = 6,
    /// <summary>
    /// Modules, configured for fog node services only
    /// </summary>
    FogDevice = 7,
    POS = 15,
    Repository = 16,
    AnalysisService = 17,
    LotZone = 18,
    RestService = 19,
    PosService = 20,
    AnprService = 21
}

public enum SystemType : int
{
    Regular = 1,
    System = 2
}

public enum SyncMode
{
    /// <summary>
    /// Nenaudojamas
    /// </summary>
    [pbr::OriginalName("OFF")] Off = 0,
    /// <summary>
    /// GRID generuojamas lokaliai ir įrašai siunčiami į nutolusį serverį.
    /// Naudojamas kai nėra INSERT/UPDATE konfliktų galimybės.
    /// </summary>
    [pbr::OriginalName("PUSH")] Push = 1,
    /// <summary>
    /// GRID generuojamas lokaliai ir įrašas siunčiamas į nutolusį serveri.
    /// Tačiau esant INSERT konfliktui nutolusiame serveryje,
    /// lokali GRID reikšmė pakeičiama nutolusio serverio reikšme. 
    /// Naudojamas kai nutolusio serverio lenta yra "tiesos" šaltinis,
    /// tačiau į ją reikia perduoti INSERT'us iš lokalaus serverio.
    /// </summary>
    [pbr::OriginalName("PULL")] Pull = 2
}