using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.CityConfiguration;

public class CityModelBuilderConfiguration : BaseModelBuilderConfiguration<City>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<City> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.HasIndex(c => c.CityCode)
            .IsUnique();

        builder.HasMany(c => c.Centers)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasData(
        new
        {
            Id = 1,
            Name = "Tehran",
            CityCode = 101,
            ProvinceCode = 21,
            ProvinceId = 1
        },
        new
        {
            Id = 2,
            Name = "Rey",
            CityCode = 102,
            ProvinceCode = 21,
            ProvinceId = 1
        },
        new
        {
            Id = 3,
            Name = "Isfahan",
            CityCode = 201,
            ProvinceCode = 31,
            ProvinceId = 2
        },
        new
        {
            Id = 4,
            Name = "Kashan",
            CityCode = 202,
            ProvinceCode = 31,
            ProvinceId = 2
        },
        new
        {
            Id = 5,
            Name = "Shiraz",
            CityCode = 301,
            ProvinceCode = 71,
            ProvinceId = 3
        },
        new
        {
            Id = 6,
            Name = "Marvdasht",
            CityCode = 302,
            ProvinceCode = 71,
            ProvinceId = 3
        },
        new
        {
            Id = 7,
            Name = "Mashhad",
            CityCode = 401,
            ProvinceCode = 51,
            ProvinceId = 4
        },
        new
        {
            Id = 8,
            Name = "Neyshabur",
            CityCode = 402,
            ProvinceCode = 51,
            ProvinceId = 4
        },
        new
        {
            Id = 9,
            Name = "Tabriz",
            CityCode = 501,
            ProvinceCode = 41,
            ProvinceId = 5
        },
        new
        {
            Id = 10,
            Name = "Maragheh",
            CityCode = 502,
            ProvinceCode = 41,
            ProvinceId = 5
        }
    );
    }
}
