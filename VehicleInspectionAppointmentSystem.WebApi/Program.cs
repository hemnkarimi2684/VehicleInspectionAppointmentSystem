using VehicleInspectionAppointmentSystem.Business.Common.Extensions;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Extensions;
using VehicleInspectionAppointmentSystem.WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "VehicleInspectionAppointmentSystem:";
});

builder.Services.AddInfrastructureDependency(builder.Configuration);
builder.Services.AddBusinessDependency();

builder.Services.AddScoped<GlobalExceptionHandlingMiddleware>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
