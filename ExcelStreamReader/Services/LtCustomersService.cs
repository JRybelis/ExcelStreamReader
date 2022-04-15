using System.Data;
using CoreData.Dtos.LtCustomers;
using ExcelDataReader;

namespace ExcelStreamReader.Services;

public class LtCustomersService
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    public static async Task<List<List<LtCustomersDto>>> ReadExcelData(string excelDocumentLocation)
    {
        // var ExcelDocumentLocation = @"C:\Users\jokubasr\Downloads\report.xlsx";
        var ltCustomersList = new List<LtCustomersDto>();

        var fileStream = File.Open(excelDocumentLocation, FileMode.Open, FileAccess.Read);
        IExcelDataReader? excelReader = null;

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
        
        var listLtCustomersDtos = new List<List<LtCustomersDto>>();
        var dataSet = excelReader.AsDataSet();
        var dataTableCollection = dataSet.Tables;
        
        foreach (DataTable table in dataTableCollection)
        {
            try
            {
                Logger.Debug($"About to call PopulateLtCustomers with {nameof(table)} data.");
                var ltCustomersDtos = await PopulateLtCustomersDtos(table);
                listLtCustomersDtos.Add(ltCustomersDtos);
            }
            catch (Exception ex)
            {
                Logger.Error($"Populating LtCustomersDtos with {nameof(table)} data failed with.", ex);
                throw;
            }
        }
        
        excelReader?.Close();
        return listLtCustomersDtos;
    }

    private static Task<List<LtCustomersDto>> PopulateLtCustomersDtos(DataTable table)
    {
        var ltCustomersDtos = new List<LtCustomersDto>(); // == table
        var ltCustomersDto = new LtCustomersDto();
        
        for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
        {
            if (rowIndex >= 0 && table.Rows.Count > rowIndex)
            {
                var row = table.Rows[rowIndex];
                if (rowIndex == 0) continue;
                
                ltCustomersDto.Id = Convert.ToInt64((double)row["Column0"]); // priskirti nereikia ? 
                ltCustomersDto.Name = (string) row["Column1"];
                ltCustomersDto.NumberPlateNo = (string) row["Column2"];
                ltCustomersDto.InLot = bool.Parse((string) row["Column3"]);
                ltCustomersDto.ValidFrom = DateTime.Parse((string) row["Column4"]);
                ltCustomersDto.ValidTo = DateTime.Parse((string) row["Column5"]);
                ltCustomersDto.Active = bool.Parse((string) row["Column6"]);
                ltCustomersDto.Slot = (string) row["Column7"];
            }
            else
            {
                throw new ArgumentNullException(exc,"An empty import document provided. Please upload relevant data to import.");
            }
            ltCustomersDtos.Add(ltCustomersDto);
        }
        return Task.FromResult(ltCustomersDtos);
    }
}