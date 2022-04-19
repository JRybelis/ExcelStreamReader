using ExcelStreamReader.Controllers;
using ExcelStreamReader.Data;
using ExcelStreamReader.Interfaces;
using ExcelStreamReader.Repositories;
using ExcelStreamReader.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog;

namespace ExcelStreamReader;

public class Startup
{
    private IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var defaultConnectionString = Configuration.GetConnectionString("DefaultConnectionString");

        var nLogConfig = new NLog.Config.LoggingConfiguration();
        // Targets where to Log to: File and Console
        var logFile = new NLog.Targets.FileTarget("logFile") {FileName = "file.txt"};
        var logConsole = new NLog.Targets.ConsoleTarget("logConsole");
        
        // Rules for mapping loggers to targets
        nLogConfig.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
        nLogConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
        
        // Apply config
        NLog.LogManager.Configuration = nLogConfig;

        services.AddAutoMapper(typeof(Startup));
        services.AddDbContext<DataContext>(d =>
        {
            if (defaultConnectionString != null) d.UseNpgsql(defaultConnectionString);
        });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(GenericControllerBase<,>));

        services.AddScoped(typeof(LtCustomersService));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExcelStreamReader", Version = "v1"});
        });
        services.AddControllers();
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExcelStreamReader v1");
                c.RoutePrefix = "swagger";
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}