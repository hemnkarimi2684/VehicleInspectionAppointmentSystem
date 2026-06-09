using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.TimeSlotConfiguration;

public class TimeSlotModelBuilderConfiguration : BaseModelBuilderConfiguration<TimeSlot>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.Property(ts => ts.IsReserved)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(ts => ts.Appointment)
            .WithOne(a => a.TimeSlot)
            .HasForeignKey<Appointment>(a => a.TimeSlotId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
        new
        {
            Id = 1,
            StartTime = new TimeOnly(8, 0),
            EndTime = new TimeOnly(8, 30),
            TimeSlotDate = new DateTime(2027, 1, 10),
            Capacity = 5,
            IsReserved = true,
            CenterId = 1
        },
        new
        {
            Id = 2,
            StartTime = new TimeOnly(8, 30),
            EndTime = new TimeOnly(9, 0),
            TimeSlotDate = new DateTime(2027, 1, 10),
            Capacity = 5,
            IsReserved = true,
            CenterId = 1
        },
        new
        {
            Id = 3,
            StartTime = new TimeOnly(9, 0),
            EndTime = new TimeOnly(9, 30),
            TimeSlotDate = new DateTime(2027, 1, 10),
            Capacity = 6,
            IsReserved = false,
            CenterId = 1
        },
        new
        {
            Id = 4,
            StartTime = new TimeOnly(10, 0),
            EndTime = new TimeOnly(10, 30),
            TimeSlotDate = new DateTime(2027, 1, 11),
            Capacity = 4,
            IsReserved = true,
            CenterId = 2
        },
        new
        {
            Id = 5,
            StartTime = new TimeOnly(10, 30),
            EndTime = new TimeOnly(11, 0),
            TimeSlotDate = new DateTime(2027, 1, 11),
            Capacity = 4,
            IsReserved = false,
            CenterId = 2
        },
        new
        {
            Id = 6,
            StartTime = new TimeOnly(11, 0),
            EndTime = new TimeOnly(11, 30),
            TimeSlotDate = new DateTime(2027, 1, 12),
            Capacity = 7,
            IsReserved = true,
            CenterId = 3
        },
        new
        {
            Id = 7,
            StartTime = new TimeOnly(12, 0),
            EndTime = new TimeOnly(12, 30),
            TimeSlotDate = new DateTime(2027, 1, 12),
            Capacity = 6,
            IsReserved = false,
            CenterId = 4
        },
        new
        {
            Id = 8,
            StartTime = new TimeOnly(13, 0),
            EndTime = new TimeOnly(13, 30),
            TimeSlotDate = new DateTime(2027, 1, 13),
            Capacity = 5,
            IsReserved = true,
            CenterId = 5
        },
        new
        {
            Id = 9,
            StartTime = new TimeOnly(13, 30),
            EndTime = new TimeOnly(14, 0),
            TimeSlotDate = new DateTime(2027, 1, 13),
            Capacity = 5,
            IsReserved = false,
            CenterId = 6
        },
        new
        {
            Id = 10,
            StartTime = new TimeOnly(14, 0),
            EndTime = new TimeOnly(14, 30),
            TimeSlotDate = new DateTime(2027, 1, 14),
            Capacity = 8,
            IsReserved = true,
            CenterId = 7
        },
        new
        {
            Id = 11,
            StartTime = new TimeOnly(14, 30),
            EndTime = new TimeOnly(15, 0),
            TimeSlotDate = new DateTime(2027, 1, 14),
            Capacity = 8,
            IsReserved = false,
            CenterId = 8
        },
        new
        {
            Id = 12,
            StartTime = new TimeOnly(15, 0),
            EndTime = new TimeOnly(15, 30),
            TimeSlotDate = new DateTime(2027, 1, 15),
            Capacity = 4,
            IsReserved = true,
            CenterId = 9
        },
        new
        {
            Id = 13,
            StartTime = new TimeOnly(15, 30),
            EndTime = new TimeOnly(16, 0),
            TimeSlotDate = new DateTime(2027, 1, 15),
            Capacity = 4,
            IsReserved = false,
            CenterId = 10
        },
        new
        {
            Id = 14,
            StartTime = new TimeOnly(16, 0),
            EndTime = new TimeOnly(16, 30),
            TimeSlotDate = new DateTime(2027, 1, 16),
            Capacity = 6,
            IsReserved = true,
            CenterId = 11
        },
        new
        {
            Id = 15,
            StartTime = new TimeOnly(16, 30),
            EndTime = new TimeOnly(17, 0),
            TimeSlotDate = new DateTime(2027, 1, 16),
            Capacity = 6,
            IsReserved = false,
            CenterId = 1
        }
    );
    }
}
