using Microsoft.Extensions.DependencyInjection;
using VehicleInspectionAppointmentSystem.Business.Interfaces.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CenterBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.CityBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TechnicalInspectionBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.UserBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.CenterBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.CityBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.TechnicalInspectionBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.UserBusiness;
using VehicleInspectionAppointmentSystem.Business.Services.VehicleBusiness;

namespace VehicleInspectionAppointmentSystem.Business.Extensions;

public static class BusinessDependencyInjection
{

    public static IServiceCollection AddBusinessDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IProvinceService, ProvinceService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<ICenterService, CenterService>();
        services.AddScoped<ITimeSlotService, TimeSlotService>();
        services.AddScoped<IAppointmentService, ApointmentService>();
        services.AddScoped<ITechnicalInspectionService, TechnicalInspectionService>();

        return services;
    }
}

