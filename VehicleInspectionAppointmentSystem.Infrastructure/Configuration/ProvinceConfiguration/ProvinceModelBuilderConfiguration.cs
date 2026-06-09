using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.ProvinceConfiguration;

public class ProvinceModelBuilderConfiguration : BaseModelBuilderConfiguration<Province>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Province> builder)
    {
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(p => p.ProvinceCode)
            .IsUnique();    

        builder.HasMany(p => p.Cities)
             .WithOne(c => c.Province)
             .HasForeignKey(c => c.ProvinceId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired();

        builder.HasData(
                      new { Id = 1, Name = "Tehran", ProvinceCode = 101 },
                      new { Id = 2, Name = "Isfahan", ProvinceCode = 102 },
                      new { Id = 3, Name = "Fars", ProvinceCode = 103 },
                      new { Id = 4, Name = "Khorasan Razavi", ProvinceCode = 104 },
                      new { Id = 5, Name = "Mazandaran", ProvinceCode = 105 }
                            );

    }
}
