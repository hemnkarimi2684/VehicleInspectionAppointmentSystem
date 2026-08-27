using System.Xml.Linq;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
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
            throw new DomainException(DomainErrors.TechnicalInspectionDescriptionIsRequired);

        if (Description.Length < 2 || Description.Length > 250)
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionDescriptionLength);

        if (IssueDate > DateTime.UtcNow)
            throw new DomainException(DomainErrors.TechnicalInspectionIssueDateTimeRange);

        if (ExpireDate < DateTime.UtcNow)
            throw new DomainException(DomainErrors.TechnicalInspectionExpireDateTimeRange);

        if (ExpireDate < IssueDate)
            throw new DomainException(DomainErrors.TechnicalInspectionExpireDateTimeRange);

        if (VehicleId < 1)
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionVehicleIdRange);

        if (string.IsNullOrWhiteSpace(VehicleVin))
            throw new DomainException(DomainErrors.TechnicalInspectionVehicleVinIsRequired);

        if (VehicleVin.Length != 17)
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionVehicleVinLength);

        if (VehicleVin.Any(char.IsSymbol))
            throw new DomainException(DomainErrors.TechnicalInspectionVehicleVinHasSymbol);

        if (string.IsNullOrWhiteSpace(VehiclePlate))
            throw new DomainException(DomainErrors.TechnicalInspectionVehiclePlateIsRequired);

        if (VehiclePlate.Length != 8)
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionVehiclePlateLength);

        if (!VehiclePlate.Any(char.IsLetter))
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionVehiclePlateFormat);

        if (!VehiclePlate.Any(char.IsDigit))
            throw new DomainException(DomainErrors.TechnicalInspectionVehiclePlateDontHaveDigit);

        if (VehiclePlate.Any(char.IsSymbol))
            throw new DomainException(DomainErrors.TechnicalInspectionVehiclePlateHasSymbol);

        if (AppointmentId < 1)
            throw new DomainException(DomainErrors.InvalidTechnicalInspectionAppointmentIdRange);
    }

    private void SetExpireDate() => ExpireDate = IssueDate.AddYears(1);

    public void UpdateResult(Result result) => Result = result;

}
