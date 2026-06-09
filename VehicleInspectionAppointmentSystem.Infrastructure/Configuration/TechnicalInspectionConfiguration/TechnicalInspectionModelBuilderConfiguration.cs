using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.TechnicalInspectionConfiguration;

public class TechnicalInspectionModelBuilderConfiguration : BaseModelBuilderConfiguration<TechnicalInspection>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<TechnicalInspection> builder)
    {
        builder.Property(ti => ti.Result)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(ti => ti.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(ti => ti.IssueDate)
            .IsRequired();

        builder.Property(ti => ti.ExpireDate)
            .IsRequired();

        builder.Property(v => v.VehicleVin)
               .IsRequired()
               .HasMaxLength(17);

        builder.Property(v => v.VehiclePlate)
               .IsRequired()
               .HasMaxLength(8);

        builder.HasData(
        new
        {
            Id = 1,
            Result = Result.Passed,
            Description = "Vehicle passed all technical and emission checks successfully.",
            IssueDate = new DateTime(2026, 1, 10),
            ExpireDate = new DateTime(2027, 1, 10),
            VehiclePlate = "12A34567",
            VehicleVin = "JTDBR32E530123456",
            VehicleId = 1,
            AppointmentId = 1
        },
        new
        {
            Id = 2,
            Result = Result.Passed,
            Description = "Inspection completed successfully with no critical issues.",
            IssueDate = new DateTime(2026, 1, 11),
            ExpireDate = new DateTime(2027, 1, 11),
            VehiclePlate = "23B45678",
            VehicleVin = "JHMFA16586S123456",
            VehicleId = 2,
            AppointmentId = 2
        },
        new
        {
            Id = 3,
            Result = Result.Failed,
            Description = "Vehicle failed due to brake system performance below standard.",
            IssueDate = new DateTime(2026, 1, 12),
            ExpireDate = new DateTime(2027, 1, 12),
            VehiclePlate = "34C56789",
            VehicleVin = "5YJ3E1EA7KF123456",
            VehicleId = 3,
            AppointmentId = 3
        },
        new
        {
            Id = 4,
            Result = Result.Rejected,
            Description = "Inspection rejected because required vehicle documents were incomplete.",
            IssueDate = new DateTime(2026, 1, 13),
            ExpireDate = new DateTime(2027, 1, 13),
            VehiclePlate = "56E78901",
            VehicleVin = "WF0XXXTTGXK123456",
            VehicleId = 5,
            AppointmentId = 5
        },
        new
        {
            Id = 5,
            Result = Result.Passed,
            Description = "Motorcycle passed safety, lighting and emission inspection.",
            IssueDate = new DateTime(2026, 1, 14),
            ExpireDate = new DateTime(2027, 1, 14),
            VehiclePlate = "78G90123",
            VehicleVin = "MLHPC4567M5123456",
            VehicleId = 7,
            AppointmentId = 7
        }
    );
    }
}
