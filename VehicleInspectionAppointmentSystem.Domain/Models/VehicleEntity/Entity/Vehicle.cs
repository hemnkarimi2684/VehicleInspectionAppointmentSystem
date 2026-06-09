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
            throw new ArgumentNullException("the car name cannot be null");

        if (Name.Length < 2 || Name.Length > 100)
            throw new InvalidOperationException("the name length cannot be less than 2 or higher than 100");

        if (string.IsNullOrWhiteSpace(Vin))
            throw new ArgumentNullException("the vin cannot be null");

        if (Vin.Length != 17)
            throw new InvalidOperationException("invalid vin! the vin length must be 17");

        if (Vin.Any(char.IsSymbol))
            throw new InvalidOperationException("invalid vin! vin have symbol");

        if(string.IsNullOrWhiteSpace(Plate))
            throw new ArgumentNullException("the Plate cannot be null");

        if(Plate.Length != 8)
            throw new InvalidOperationException("the Plate length must be 8 characters!");

        if(!Plate.Any(char.IsLetter))
            throw new InvalidOperationException("the Plate must have one letter in between the numbers like 11 .. 111 11");

        if(!Plate.Any(char.IsDigit))
            throw new InvalidOperationException("the Plate must have numbers like 11 .. 111 11");

        if (string.IsNullOrWhiteSpace(Brand))
            throw new ArgumentNullException("the brand name cannot be null");

        if (Brand.Length < 2 || Brand.Length > 120)
            throw new InvalidOperationException("the brand name length cannot be less than 2 or higher than 120");

        if (!string.IsNullOrWhiteSpace(Color) && Color.Length < 0 || Color.Length > 100)
            throw new InvalidOperationException("the brand name length cannot be less than 1 or higher than 100");

        if (ProductionYear < 0 || ProductionYear > DateTime.UtcNow.Year)
            throw new InvalidTimeZoneException("invalid production year!");

        if (string.IsNullOrWhiteSpace(ManufacturerCompany))
            throw new ArgumentNullException("the ManufacturerCompany cannot be null");

        if (ManufacturerCompany.Length < 2 || ManufacturerCompany.Length > 150)
            throw new InvalidOperationException("the ManufacturerCompany cannot be less than 2 or higher than 150");

        if (UserId < 1)
            throw new InvalidOperationException("invalid userId! the user id cannot be negative");
    }

    public void UpdateColor(string color) => Color = color;
}
