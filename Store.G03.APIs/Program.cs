
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G03.APIs.Error;
using Store.G03.Core;
using Store.G03.Core.Mapping.Products;
using Store.G03.Core.Services.contract;
using Store.G03.Repository;
using Store.G03.Repository.Data;
using Store.G03.Repository.Data.context;
using Store.G03.Service.Services;
using Store.G03.APIs.Helper;
namespace Store.G03.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependency(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
       
           
           
        
            var app = builder.Build();
            await app.CongigureMiddleWares();

            app.Run();
        }
    }
}
