using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.AppointmentConfiguration;

public class AppointmentModelBuilderConfiguration : BaseModelBuilderConfiguration<Appointment>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Appointment> builder)
    {
        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.Amount)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.PaymentType)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(a => new { a.VehicleId, a.TimeSlotId })
       .IsUnique();

        builder.HasOne(a => a.TechnicalInspection)
            .WithOne(ti => ti.Appointment)
            .HasForeignKey<TechnicalInspection>(ti => ti.AppointmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
        new
        {
            Id = 1,
            Status = Status.Active,
            Amount = 450000m,
            PaymentType = PaymentType.Card,
            VehicleId = 1,
            TimeSlotId = 1
        },
        new
        {
            Id = 2,
            Status = Status.Done,
            Amount = 450000m,
            PaymentType = PaymentType.credit,
            VehicleId = 2,
            TimeSlotId = 2
        },
        new
        {
            Id = 3,
            Status = Status.Active,
            Amount = 520000m,
            PaymentType = PaymentType.Card,
            VehicleId = 3,
            TimeSlotId = 4
        },
        new
        {
            Id = 4,
            Status = Status.Cancelled,
            Amount = 0m,
            PaymentType = PaymentType.Card,
            VehicleId = 4,
            TimeSlotId = 6
        },
        new
        {
            Id = 5,
            Status = Status.Done,
            Amount = 600000m,
            PaymentType = PaymentType.credit,
            VehicleId = 5,
            TimeSlotId = 8
        },
        new
        {
            Id = 6,
            Status = Status.Active,
            Amount = 450000m,
            PaymentType = PaymentType.Card,
            VehicleId = 6,
            TimeSlotId = 10
        },
        new
        {
            Id = 7,
            Status = Status.Done,
            Amount = 300000m,
            PaymentType = PaymentType.Card,
            VehicleId = 7,
            TimeSlotId = 12
        },
        new
        {
            Id = 8,
            Status = Status.Active,
            Amount = 650000m,
            PaymentType = PaymentType.credit,
            VehicleId = 8,
            TimeSlotId = 14
        }
    );

    }
}
