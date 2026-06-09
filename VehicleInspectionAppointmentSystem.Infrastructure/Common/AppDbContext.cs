using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Common;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Center> Centers => Set<Center>();
    public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
    public DbSet<Province> Provinces => Set<Province>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<TechnicalInspection> TechnicalInspections => Set<TechnicalInspection>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
