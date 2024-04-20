
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Controllers.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contruct;
using Talabat.Repository;
using Talabat.Repository.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<StoreContext>(Option =>
            {
                Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            ///builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<Product>>();
            ///builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<ProductBrand>>();
            ///builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<ProductCategory>>();

            builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {

                options.InvalidModelStateResponseFactory = (action) =>
                {
                    var errors = action.ModelState.Where(P => P.Value.Errors.Count()>0)
                                                 .SelectMany(V => V.Value.Errors)
                                                 .Select(E => E.ErrorMessage)
                                                 .ToList();
                    var ValidatRes = new ValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidatRes);
                };
            });

            var app = builder.Build();

            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var _dbContext = services.GetRequiredService<StoreContext>(); // Ask CLR for creating object from DbContext Explicitly

            var loggerFactory = services.GetRequiredService<ILoggerFactory>(); // Ask CLR for creating object from ILoggerFactory Explicitly

            try
            {
                await _dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has been occured during apply the migration");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}