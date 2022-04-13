

namespace ExcelStreamReaderConsole;

class Program
{
    static void Main(string[] args)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        var ExcelDocumentLocation = @"C:\Users\jokubasr\Downloads\report.xlsx";
        var longTermCustomerService = new LtCustomersService();
        var ltCustomersListDocument = LtCustomersService.ReadExcelData(ExcelDocumentLocation);
        var ltCustomersList = new List<LtCustomers>();

    }
      
}

