using System.Data;
using System.Globalization;
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
        IExcelDataReader? excelReader = null;
        
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var fileStream = File.Open(excelDocumentLocation, FileMode.Open, FileAccess.Read);
        
        try
        {
            if (excelDocumentLocation.EndsWith(".xls"))
            {
                excelReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                // excelReader = ExcelReaderFactory.CreateCsvReader(fileStream);
            }

            if (excelDocumentLocation.EndsWith(".xlsx"))
            {
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            }
        }
        catch (Exception e)
        {
            Logger.Error(e);
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
            catch (Exception)
            {
                Logger.Error($"Populating LtCustomersDtos with {nameof(table)} data failed with.");
                throw;
            }
        }
        
        excelReader?.Close();
        return listLtCustomersDtos;
    }

    private static Task<List<LtCustomersDto>> PopulateLtCustomersDtos(DataTable table)
    {
        var ltCustomersDtos = new List<LtCustomersDto>(); // == table
        
        for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
        {
            if (rowIndex >= 0 && table.Rows.Count > rowIndex)
            {
                var ltCustomersDto = new LtCustomersDto();
                var row = table.Rows[rowIndex];
                
                if (rowIndex == 0) continue;

                ltCustomersDto.LtcGroupId = /*Convert.ToInt64((double)row["Column0"]); */long.Parse(row["Column0"].ToString());
                ltCustomersDto.LtCustomerName = row["Column1"].ToString();
                ltCustomersDto.PlateNumber = row["Column2"].ToString();
                ltCustomersDto.Comment = row["Column3"].ToString() ?? "-"; // Comments - optional
                ltCustomersDto.IsInLot = bool.Parse(row["Column4"].ToString());
                ltCustomersDto.ValidFrom = DateTime.ParseExact(row["Column5"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                ltCustomersDto.ValidTo = DateTime.ParseExact(row["Column6"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                ltCustomersDto.Enabled = bool.Parse(row["Column7"].ToString());
                ltCustomersDto.LotPlaceTitle = row["Column8"].ToString();
                ltCustomersDto.AdditionalPlateNumbers = row["Column9"].ToString() ?? "-"; // AdditionalPlateNumbers - optional 
                
                
                ltCustomersDtos.Add(ltCustomersDto);
            }
            else
            {
                throw new ArgumentNullException(nameof(table),"An empty import document provided. Please upload relevant data to import.");
            }
        }
        return Task.FromResult(ltCustomersDtos);
    }
}