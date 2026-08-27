using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;

//نوبت 
public class Appointment : BaseEntity
{
    private Appointment() { }

    public Appointment(Status status, decimal amount, PaymentType paymentType, int vehicleId, int timeSlotId)
    {
        Status = status;
        Amount = amount;
        PaymentType = paymentType;
        VehicleId = vehicleId;
        TimeSlotId = timeSlotId;

        Validate();
    }

    public Status Status { get; private set; }

    public decimal Amount { get; private set; }

    public PaymentType PaymentType { get; private set; }

    //Foreign Key
    public int VehicleId { get; private set; }
    public int TimeSlotId { get; private set; }

    //Navigation Properties
    public virtual Vehicle Vehicle { get; private set; }
    public virtual TimeSlot TimeSlot { get; private set; }
    public TechnicalInspection TechnicalInspection { get; private set; }

    protected override void Validate()
    {
        if (Amount < 0)
            throw new DomainException(DomainErrors.InvalidAppointmentAmountRange);

        if (VehicleId < 1)
            throw new DomainException(DomainErrors.InvalidAppointmentVehicleIdRange);

        if (TimeSlotId < 1)
            throw new DomainException(DomainErrors.InvalidAppointmentTimeSlotIdRange);
    }
}
