using Npgsql;
using OffersManagement.Application;
using OffersManagement.Domain.Contracts;
using OffersManagement.Host.WebApi;
using OffersManagement.Infrastructure;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                                  .AddJsonFile("appsettings.json", true, true)
                                  .Build();

// Add services to the container.
var services = builder.Services;
{
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Dependency Injections
    services.AddScoped<IOfferService, OfferService>();
    services.AddScoped<IOfferConverter, OfferConverter>();
    services.AddScoped<IDbConnection>(db => new NpgsqlConnection(configuration.GetConnectionString("OffersDatabase")));
    services.AddScoped<IDapperWrapper, DapperWrapper>();
    services.AddScoped<IOfferRepository, OfferRepository>();
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IPriceRepository, PriceRepository>();
    services.AddScoped<IStockRepository, StockRepository>();

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler(configuration["ErrorHandling:Path"]);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

public partial class Program { }



