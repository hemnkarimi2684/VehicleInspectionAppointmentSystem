using System.ComponentModel.DataAnnotations;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;

// بازه زمانی 
public class TimeSlot : BaseEntity
{
    private TimeSlot() { }

    public TimeSlot(TimeOnly startTime, DateTime timeSlotDate, int capacity, bool isReserved, int centerId)
    {
        StartTime = startTime;
        TimeSlotDate = timeSlotDate;
        Capacity = capacity;
        IsReserved = isReserved;
        CenterId = centerId;

        SetEndTime();
        Validate();
    }

    public TimeOnly StartTime { get; private set; }

    public TimeOnly EndTime { get; private set; }

    public DateTime TimeSlotDate { get; private set; }

    public int Capacity { get; private set; }

    public bool IsReserved { get; private set; }

    //Foreign Key
    public int CenterId { get; private set; }

    //Navigation Key
    public virtual Center Center { get; private set; }
    public virtual Appointment Appointment { get; private set; }

    protected override void Validate()
    {
        if (TimeSlotDate < DateTime.UtcNow)
            throw new InvalidOperationException("invalid TimeSlotDate of Time Slot! the reserved date cannot be in the past");

        if (StartTime.Hour < 1 || StartTime.Hour > 18 || StartTime.Minute != 00 && StartTime.Minute != 30)
            throw new InvalidOperationException("Invalid start time. Allowed hours are between 01:00 and 18:00, and minutes must be either 00 or 30.");

        if (CenterId < 1)
            throw new InvalidOperationException("invalid centerId input! the center id cannot be negative");

        if (Capacity < 1)
            throw new InvalidOperationException("invalid Capacity input! the Capacity cannot be negative");
    }

    private void SetEndTime() => EndTime = StartTime.AddMinutes(30);

    public void UpdateReservedStatus(bool isReserved)
    {
        Update();
        IsReserved = isReserved;
    }
   
}
