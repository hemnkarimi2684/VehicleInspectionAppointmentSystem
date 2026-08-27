using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.AppointmentRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CenterRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CityRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.ProvinceRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TechnicalInspectionRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TimeSlotRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.UserRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.VehicleRepo;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Extensions;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options
             .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<ICenterRepository, CenterRepositoy>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ITechnicalInspectionRepository, TechnicalInspectionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
