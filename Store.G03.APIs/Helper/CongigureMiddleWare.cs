using Microsoft.EntityFrameworkCore;
using Store.G03.Repository.Data;
using Store.G03.Repository.Data.context;

namespace Store.G03.APIs.Helper
{
    public static class CongigureMiddleWare
    {
        public static async Task<WebApplication> CongigureMiddleWares(this WebApplication app)
        {
            using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreDbContext>();
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);

            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "there are problems duuring apply miggrations");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            return app;
        }
    }
}
