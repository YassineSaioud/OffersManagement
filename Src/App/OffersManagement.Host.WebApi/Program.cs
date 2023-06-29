using OffersManagement.Application.Commands;
using OffersManagement.Domain.Contracts;
using OffersManagement.Host.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
{
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Dependency Injections
    services.AddScoped<IOfferAdapter, OfferAdapter>();
    services.AddScoped<IOfferConverter, OfferConverter>();
    services.AddScoped<IOfferCommandReader, OfferCommandReader>();
    services.AddScoped<IOfferCommandWriter, OfferCommandWriter>();

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


