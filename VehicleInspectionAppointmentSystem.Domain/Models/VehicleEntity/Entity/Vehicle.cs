using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Enums;

namespace VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;

// ماشین
public class Vehicle : BaseEntity
{
    private Vehicle() { }
    
    public Vehicle(string name, string vin, string plate, string brand, string? color, int productionYear, string manufacturerCompany, bool isActive ,FuelType fuelType, VehicleType vehicleType, int userId)
    {
        Name = name;
        Vin = vin;
        Plate = plate;
        Brand = brand;
        Color = color;
        ProductionYear = productionYear;
        ManufacturerCompany = manufacturerCompany;
        IsActive = isActive;
        FuelType = fuelType;
        VehicleType = vehicleType;
        UserId = userId;

        //Methods
        Validate();
    }

    public string Name { get; private set; }

    public string Vin { get; private set; }

    public string Plate { get; private set; }

    public string Brand { get; private set; }

    public string? Color { get; private set; }

    public int ProductionYear { get; private set; }

    public string ManufacturerCompany { get; private set; }

    public bool IsActive { get; private set; }

    public FuelType FuelType { get; private set; }

    public VehicleType VehicleType { get; private set; }

    //Foreign Key
    public int UserId { get; private set; }

    //Navigation Properties
    public User User { get; private set; }

    public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

    public ICollection<TechnicalInspection> TechnicalInspections { get; private set; } = new List<TechnicalInspection>();

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException(DomainErrors.VehicleNameIsRequired);

        if (Name.Length < 2 || Name.Length > 100)
            throw new DomainException(DomainErrors.InvalidVehicleNameLength);

        if (string.IsNullOrWhiteSpace(Vin))
            throw new DomainException(DomainErrors.VehicleVinIsRequired);

        if (Vin.Length != 17)
            throw new DomainException(DomainErrors.InvalidVehicleVinLength);

        if (Vin.Any(char.IsSymbol))
            throw new DomainException(DomainErrors.VehicleVinHasSymbol);

        if(string.IsNullOrWhiteSpace(Plate))
            throw new DomainException(DomainErrors.VehiclePlateIsRequired);

        if(Plate.Length != 8)
            throw new DomainException(DomainErrors.InvalidVehiclePlateLength);

        if(!Plate.Any(char.IsLetter))
            throw new DomainException(DomainErrors.InvalidVehiclePlateFormat);

        if(!Plate.Any(char.IsDigit))
            throw new DomainException(DomainErrors.VehiclePlateDontHaveDigit);

        if (Plate.Any(char.IsSymbol))
            throw new DomainException(DomainErrors.VehiclePlateHasSymbol);

        if (string.IsNullOrWhiteSpace(Brand))
            throw new DomainException(DomainErrors.VehicleBrandIsRequired);

        if (Brand.Length < 2 || Brand.Length > 120)
            throw new DomainException(DomainErrors.InvalidVehicleBrandLength);

        if (!string.IsNullOrWhiteSpace(Color) && Color.Length < 0 || Color.Length > 100)
            throw new DomainException(DomainErrors.InvalidVehicleColorLength);

        if (ProductionYear < 0 || ProductionYear > DateTime.UtcNow.Year)
            throw new DomainException(DomainErrors.InvalidVehicleProductionYear);

        if (string.IsNullOrWhiteSpace(ManufacturerCompany))
            throw new DomainException(DomainErrors.VehicleManufacturerCompanyIsRequired);

        if (ManufacturerCompany.Length < 2 || ManufacturerCompany.Length > 150)
            throw new DomainException(DomainErrors.InvalidVehicleManufacturerCompanyLength);

        if (UserId < 1)
            throw new DomainException(DomainErrors.InvalidVehicleUserIdRange);
    }

    public void UpdateColor(string color) => Color = color;
}
