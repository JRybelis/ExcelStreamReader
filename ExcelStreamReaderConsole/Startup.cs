using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelStreamReaderConsole.Controllers;
using ExcelStreamReaderConsole.Data;
using ExcelStreamReaderConsole.Interfaces;
using ExcelStreamReaderConsole.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExcelStreamReaderConsole;

public class Startup
{
    public IConfiguration Configuration { get; set; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var defaultConnectionString = Configuration.GetConnectionString("DefaultConnectionString");

        services.AddAutoMapper(typeof(Startup));
        services.AddDbContext<DataContext>(d => d.UseNpgsql(defaultConnectionString));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(GenericControllerBase<,>));

        services.AddScoped(typeof(LtCustomersService<>));

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "ExcelStreamReader", Version = "v1"});
        });
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP requet pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExcelStreamReader v1"));
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