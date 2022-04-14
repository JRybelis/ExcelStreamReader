using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExcelStreamReader;

class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

