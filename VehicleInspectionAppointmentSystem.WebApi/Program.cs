using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Business.Businesses.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.CenterBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.CityBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.TechnicalInspectionBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.UserBusiness;
using VehicleInspectionAppointmentSystem.Business.Businesses.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Service;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.AppointmentRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CenterRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CityRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.ProvinceRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TechnicalInspectionRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TimeSlotRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.UserRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.VehicleRepo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ICenterRepository, CenterRepositoy>();
builder.Services.AddScoped<ICenterService, CenterService>();

builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, ApointmentService>();

builder.Services.AddScoped<ITechnicalInspectionRepository, TechnicalInspectionRepository>();
builder.Services.AddScoped<ITechnicalInspectionService, TechnicalInspectionService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
