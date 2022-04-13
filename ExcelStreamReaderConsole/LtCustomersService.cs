using System.Data;
using ExcelDataReader;

namespace ExcelStreamReaderConsole;

public class LtCustomersService
{
    public static async Task<List<List<LtCustomers>>> ReadExcelData(string excelDocumentLocation)
    {
        FileStream fileStream = File.Open(excelDocumentLocation, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = null;

        try
        {
            if (excelDocumentLocation.EndsWith(".xls"))
            {
                // excelReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                excelReader = ExcelReaderFactory.CreateCsvReader(fileStream);
            }

            if (excelDocumentLocation.EndsWith(".xlsx"))
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        var dataSet = excelReader.AsDataSet();
        var dataTableCollection = dataSet.Tables;
        var tableImports = new List<List<LtCustomers>>();
        
        foreach (DataTable table in dataTableCollection)
        {
            var importList = await PopulateLtCustomers(table);
            tableImports.Add(importList);
        }
        
        excelReader.Close();
        return tableImports;
    }

    private static async Task<List<LtCustomers>> PopulateLtCustomers(DataTable table)
    {
        var importList = new List<LtCustomers>();
        var rowItem = new LtCustomers();
        for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
        {
            var row = table.Rows[rowIndex];
            if (rowIndex == 0) continue;
                
            rowItem.Id = Convert.ToInt64((double)row["Column0"]); // priskirti nereikia ? 
            rowItem.LtCustomerName = (string) row["Column1"];
            rowItem.PlateNumber = (string) row["Column2"];
            rowItem.IsInLot = bool.Parse((string) row["Column3"]);
            rowItem.ValidFrom = DateTime.Parse((string) row["Column4"]);
            rowItem.ValidTo = DateTime.Parse((string) row["Column5"]);
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
            importList.Add(rowItem);
        };
        return importList;
    }
}