using System.Data;
using ExcelDataReader;

namespace ExcelStreamReaderConsole;

class Program
{
    static void Main(string[] args)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        Console.WriteLine("Hello, World!");
        
        var ExcelDocumentLocation = @"C:\Users\jokubasr\Downloads\report.xlsx";
       
        var readExcelDataSet = LtCustomersService.ReadExcelData(ExcelDocumentLocation);
        
        Console.WriteLine("The raw xml:");
        Console.WriteLine(readExcelDataSet.GetXml());
        
        DataTableCollection collection = readExcelDataSet.Tables;
        
        foreach (DataTable item in collection)
        {
            var rowItem = new LtCustomers();
            for (var rowIndex = 0; rowIndex < item.Rows.Count; rowIndex++)
            {
                var row = item.Rows[rowIndex];
                if (rowIndex == 0) continue;
                
                Console.WriteLine();
                Console.WriteLine("Pavadinimas: {0}", row["Column1"]);
                Console.WriteLine("Valst.Nr.: {0}", row["Column2"]);
                Console.WriteLine("Aikštelėje: {0}", row["Column3"]);
                Console.WriteLine("Galioja nuo: {0}", row["Column4"]);
                Console.WriteLine("Galioja iki: {0}", row["Column5"]);
                Console.WriteLine("Aktyvus: {0}", row["Column6"]);
                Console.WriteLine("Vieta: {0}", row["Column7"]);


                rowItem.Id = Convert.ToInt64(row["Column0"]); // priskirti nereikia ? 
                rowItem.LtCustomerName = (string) row["Column1"];
                rowItem.PlateNumber = (string) row["Column2"];
                rowItem.IsInLot = bool.Parse((string) row["Column3"]);
                rowItem.ValidFrom = (DateTime) row["Column4"];
                rowItem.ValidTo = (DateTime) row["Column5"];
                rowItem.Enabled = bool.Parse((string) row["Column6"]);
                rowItem.LotPlaceTitle = (string) row["Column7"];
                /*LtcGroupId = 0,
                Comment = null,
                
                PincodeHash = null,
                CustomerId = 0,
                LotPlaceId = 0,
                VehicleType = (VehicleTypeEnum) 0,
                LtcGroupName = null,
                CustomerName = null,
                CompanyDetailsId = 0,
                IsLtCustomerAdditionalPlate = false,
                    
                AdditionalPlateNumbers = null,
                PaymentOption = (PaymentOptionsEnum) 0,
                
                VehicleTypeTitle = null,
                UsersLogActionId = UsersLogActionEnum.Unknown*/
            };
                
            }
        }
      
}

