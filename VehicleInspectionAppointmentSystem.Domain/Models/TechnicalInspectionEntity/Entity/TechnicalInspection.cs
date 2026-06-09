using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;

// نتیجه معاینه فنی
public class TechnicalInspection : BaseEntity
{
    private TechnicalInspection() { }

    public TechnicalInspection(Result result, string description, DateTime issueDate, string vehiclePlate, string vehicleVin, int vehicleId, int appointmentId)
    {
        Result = result;
        Description = description;
        IssueDate = issueDate;
        VehiclePlate = vehiclePlate;
        VehicleVin = vehicleVin;
        VehicleId = vehicleId;
        AppointmentId = appointmentId;

        SetExpireDate();
        Validate();
    }

    public Result Result { get; private set; }

    public string Description { get; private set; }

    public DateTime IssueDate { get; private set; }

    public DateTime ExpireDate { get; private set; }

    public string VehiclePlate { get; private set; }

    public string VehicleVin { get; private set; }

    //Foreign Key
    public int VehicleId { get; private set; }
    public int AppointmentId { get; private set; }

    //Navigation Property
    public Vehicle Vehicle { get; private set; }
    public Appointment Appointment { get; private set; }

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Description))
            throw new ArgumentNullException("the Description cannot be null");

        if (Description.Length < 2 || Description.Length > 250)
            throw new InvalidOperationException("the Description length cannot be less than 2 or higher than 250");

        if (IssueDate > DateTime.UtcNow)
            throw new InvalidTimeZoneException("invalid IssueDate!");

        if (ExpireDate < DateTime.UtcNow)
            throw new InvalidTimeZoneException("invalid ExpireDate!");

        if (ExpireDate < IssueDate)
            throw new InvalidTimeZoneException("the issueDate cannot higher than ExpireDate");

        if (VehicleId < 1)
            throw new InvalidOperationException("invalid VehicleId! the AppointmentId cannot be negative");

        if (AppointmentId < 1)
            throw new InvalidOperationException("invalid AppointmentId! the AppointmentId cannot be negative");
    }

    private void SetExpireDate() => ExpireDate = IssueDate.AddYears(1);

    public void UpdateResult(Result result) => Result = result;

}
