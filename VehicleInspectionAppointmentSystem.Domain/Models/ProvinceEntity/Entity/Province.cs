using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
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
            throw new DomainException(DomainErrors.InvalidProvinceCodeRange);

        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException(DomainErrors.ProvinceNameIsRequired);

        if (Name.Length < 2 || Name.Length > 150)
            throw new DomainException(DomainErrors.InvalidProvinceNameLength);
    }
}
