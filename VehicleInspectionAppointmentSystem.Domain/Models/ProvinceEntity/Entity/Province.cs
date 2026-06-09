using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Entity;

public class Province : BaseEntity
{
    private Province() { }

    public Province(string name, int provinceCode)
    {
        Name = name;
        ProvinceCode = provinceCode;

        Validate();
    }

    public string Name { get; private set; }

    public int ProvinceCode { get; private set; }

    //Navigation Properties
    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    protected override void Validate()
    {
        if (ProvinceCode < 1)
            throw new InvalidOperationException("invalid ProvinceCode!");

        if (string.IsNullOrWhiteSpace(Name))
            throw new ArgumentNullException("the Province name cannot be null");

        if (Name.Length < 2 || Name.Length > 150)
            throw new InvalidOperationException("the name length cannot be less than 2 or higher than 150");
    }
}
