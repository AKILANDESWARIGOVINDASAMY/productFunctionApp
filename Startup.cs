using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;


[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{    
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connStr = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<ProductDbContext>(
              option => option.UseSqlServer(connStr));

            builder.Services.AddHttpClient();
        }
    }
}
