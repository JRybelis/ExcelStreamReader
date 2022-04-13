using System.Data;
using ExcelDataReader;

namespace ExcelStreamReaderConsole;

public class LtCustomersService
{
    public static DataSet ReadExcelData(string excelDocumentLocation)
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
        
        DataSet resultDataSet = excelReader.AsDataSet();
        excelReader.Close();
        
        return resultDataSet;
    }    
}