using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Enums;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.VehicleConfiguration;

public class VehicleModelBuilderConfiguration : BaseModelBuilderConfiguration<Vehicle>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.Vin)
            .IsRequired()
            .HasMaxLength(17);

        builder.HasIndex(v => v.Vin)
            .IsUnique();

        builder.Property(v => v.Plate)
            .IsRequired()
            .HasMaxLength(8);

        builder.HasIndex(v => v.Plate)
            .IsUnique();

        builder.Property(v => v.Brand)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(v => v.Color)
            .HasMaxLength(100);

        builder.Property(v => v.ProductionYear)
            .IsRequired();

        builder.Property(v => v.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(v => v.ManufacturerCompany)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(v => v.FuelType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(v => v.VehicleType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasMany(v => v.Appointments)
            .WithOne(a => a.Vehicle)
            .HasForeignKey(a => a.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(v => v.TechnicalInspections)
            .WithOne(ti => ti.Vehicle)
            .HasForeignKey(ti => ti.VehicleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
        new
        {
            Id = 1,
            Name = "Corolla",
            Vin = "JTDBR32E530123456",
            Plate = "12A34567",
            Brand = "Toyota",
            Color = "White",
            ProductionYear = 2018,
            ManufacturerCompany = "Toyota Motor Corporation",
            IsActive = true,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Ride,
            UserId = 1
        },
        new
        {
            Id = 2,
            Name = "Civic",
            Vin = "JHMFA16586S123456",
            Plate = "23B45678",
            Brand = "Honda",
            Color = "Black",
            ProductionYear = 2019,
            ManufacturerCompany = "Honda Motor Company",
            IsActive = true,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Ride,
            UserId = 2
        },
        new
        {
            Id = 3,
            Name = "Model Three",
            Vin = "5YJ3E1EA7KF123456",
            Plate = "34C56789",
            Brand = "Tesla",
            Color = "Blue",
            ProductionYear = 2021,
            ManufacturerCompany = "Tesla Inc",
            IsActive = true,
            FuelType = FuelType.Electricity,
            VehicleType = VehicleType.Ride,
            UserId = 3
        },
        new
        {
            Id = 4,
            Name = "Actros",
            Vin = "WDB9634031L123456",
            Plate = "45D67890",
            Brand = "Mercedes",
            Color = "Silver",
            ProductionYear = 2017,
            ManufacturerCompany = "Mercedes Benz Trucks",
            IsActive = true,
            FuelType = FuelType.CNG,
            VehicleType = VehicleType.Truck,
            UserId = 4
        },
        new
        {
            Id = 5,
            Name = "Transit",
            Vin = "WF0XXXTTGXK123456",
            Plate = "56E78901",
            Brand = "Ford",
            Color = "White",
            ProductionYear = 2016,
            ManufacturerCompany = "Ford Motor Company",
            IsActive = true,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Bus,
            UserId = 5
        },
        new
        {
            Id = 6,
            Name = "Yaris",
            Vin = "JTDKT923975123456",
            Plate = "67F89012",
            Brand = "Toyota",
            Color = "Red",
            ProductionYear = 2020,
            ManufacturerCompany = "Toyota Motor Corporation",
            IsActive = true,
            FuelType = FuelType.SuperGasoline,
            VehicleType = VehicleType.Taxi,
            UserId = 6
        },
        new
        {
            Id = 7,
            Name = "CBR",
            Vin = "MLHPC4567M5123456",
            Plate = "78G90123",
            Brand = "Honda",
            Color = "Red",
            ProductionYear = 2022,
            ManufacturerCompany = "Honda Motor Company",
            IsActive = true,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Motorcycle,
            UserId = 7
        },
        new
        {
            Id = 8,
            Name = "Hilux",
            Vin = "MR0EX3CD901123456",
            Plate = "89H01234",
            Brand = "Toyota",
            Color = "Gray",
            ProductionYear = 2015,
            ManufacturerCompany = "Toyota Motor Corporation",
            IsActive = true,
            FuelType = FuelType.CNG,
            VehicleType = VehicleType.Truck,
            UserId = 8
        },
        new
        {
            Id = 9,
            Name = "Camry",
            Vin = "4T1BF1FK5HU123456",
            Plate = "90J12345",
            Brand = "Toyota",
            Color = "Black",
            ProductionYear = 2018,
            ManufacturerCompany = "Toyota Motor Corporation",
            IsActive = false,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Ride,
            UserId = 10
        },
        new
        {
            Id = 10,
            Name = "Sprinter",
            Vin = "WD3PE8CC6D5123456",
            Plate = "11K23456",
            Brand = "Mercedes",
            Color = "White",
            ProductionYear = 2014,
            ManufacturerCompany = "Mercedes Benz Vans",
            IsActive = true,
            FuelType = FuelType.CNG,
            VehicleType = VehicleType.Bus,
            UserId = 1
        },
        new
        {
            Id = 11,
            Name = "Accord",
            Vin = "1HGCV1F34JA123456",
            Plate = "22L34567",
            Brand = "Honda",
            Color = "Silver",
            ProductionYear = 2019,
            ManufacturerCompany = "Honda Motor Company",
            IsActive = true,
            FuelType = FuelType.SuperGasoline,
            VehicleType = VehicleType.Ride,
            UserId = 2
        },
        new
        {
            Id = 12,
            Name = "Ranger",
            Vin = "1FTER4FH5KLA12345",
            Plate = "33M45678",
            Brand = "Ford",
            Color = "Green",
            ProductionYear = 2020,
            ManufacturerCompany = "Ford Motor Company",
            IsActive = true,
            FuelType = FuelType.Gasoline,
            VehicleType = VehicleType.Truck,
            UserId = 3
        }
    );
    }
}
