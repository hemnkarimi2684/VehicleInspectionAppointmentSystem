using System.ComponentModel.DataAnnotations;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
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
            throw new DomainException(DomainErrors.InvalidTiemSlotDateTimeRange);

        if (StartTime.Hour < 1 || StartTime.Hour > 18 || StartTime.Minute != 00 && StartTime.Minute != 30)
            throw new DomainException(DomainErrors.InvalidTiemSlotStartTimeRange);

        if (CenterId < 1)
            throw new DomainException(DomainErrors.InvalidTimeSLotCenterIdRange);

        if (Capacity < 1)
            throw new DomainException(DomainErrors.InvalidTimeSlotCapacityRange);
    }

    private void SetEndTime() => EndTime = StartTime.AddMinutes(30);

    public void UpdateReservedStatus(bool isReserved)
    {
        Update();
        IsReserved = isReserved;
    }
   
}
