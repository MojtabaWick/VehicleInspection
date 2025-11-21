using Microsoft.EntityFrameworkCore;
using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.InspectionRequestAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.OperatorAgg.Contracts;
using VehicleInspection.Domain.Service.AppServices.CarAgg;
using VehicleInspection.Domain.Service.AppServices.InspectionRequestAgg;
using VehicleInspection.Domain.Service.AppServices.ManufacturerAgg;
using VehicleInspection.Domain.Service.AppServices.OperatorAgg;
using VehicleInspection.Domain.Service.Services.CarAgg;
using VehicleInspection.Domain.Service.Services.DeniedInspectionRequestAgg;
using VehicleInspection.Domain.Service.Services.InspectionRequestAgg;
using VehicleInspection.Domain.Service.Services.ManufacturerAgg;
using VehicleInspection.Domain.Service.Services.OperatorAgg;
using VehicleInspection.Framework.FileService;
using VehicleInspection.Infrastructure.EFCore.Persistence;
using VehicleInspection.Infrastructure.EFCore.Repositories.CarAgg;
using VehicleInspection.Infrastructure.EFCore.Repositories.DeniedInspectionRequestAgg;
using VehicleInspection.Infrastructure.EFCore.Repositories.InspectionRequestAgg;
using VehicleInspection.Infrastructure.EFCore.Repositories.ManufacturerAgg;
using VehicleInspection.Infrastructure.EFCore.Repositories.OperatorAgg;

var builder = WebApplication.CreateBuilder(args);

#region ServiceRegistrations

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ICarAppService, CarAppService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddScoped<IDeniedInspectionRequestService, DeniedInspectionRequestService>();
builder.Services.AddScoped<IDeniedInspectionRequestRepository, DeniedInspectionRequestRepository>();

builder.Services.AddScoped<IInspectionRequestAppService, InspectionRequestAppService>();
builder.Services.AddScoped<IInspectionRequestService, InspectionRequestService>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();

builder.Services.AddScoped<IManufacturerAppService, ManufacturerAppService>();
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=VehicleInspection;Trusted_Connection=True;"));

#endregion ServiceRegistrations

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();