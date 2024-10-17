using Microsoft.EntityFrameworkCore;
using Store.G03.Core.Services.contract;
using Store.G03.Core;
using Store.G03.Repository;
using Store.G03.Repository.Data.context;
using Store.G03.Service.Services;
using System.Runtime.CompilerServices;
using Store.G03.Core.Mapping.Products;
using Microsoft.AspNetCore.Mvc;
using Store.G03.APIs.Error;

namespace Store.G03.APIs.Helper
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDependency(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddBuiltInService();
            services.AddSwaggerService();
            services.AddDBContextService(configuration);
            services.AddUserDefinedService();
            services.AddAutoMapperService(configuration);
            services.CongigureInvalidModelStateService();
           

            return services;
        }
        public static IServiceCollection AddBuiltInService(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }

        public static IServiceCollection AddDBContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
        public static IServiceCollection AddUserDefinedService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWorkcs, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(M => M.AddProfile(new ProductProfile(configuration)));
            return services;
        }

        public static IServiceCollection CongigureInvalidModelStateService(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                      .SelectMany(P => P.Value.Errors)
                      .Select(E => E.ErrorMessage)
                      .ToArray();

                    var response = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            }
        );
            return services;
        }
    }
}