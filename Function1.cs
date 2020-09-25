using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;
using ProductManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ProductAPI.Models.Data;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.AspNetCore.Routing;


namespace FunctionApp
{
    public class HttpWebAPI
    {
        private readonly ProductDbContext _context;

        public HttpWebAPI(ProductDbContext context)
        {
            _context = context;
        }

        [FunctionName("GetProducts")]
        public IActionResult GetProducts(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request.");

            var productsArray = _context.Productdetails.OrderBy(s => s.Productid).ToArray();

            return new OkObjectResult(productsArray);
        }

       
    }
}