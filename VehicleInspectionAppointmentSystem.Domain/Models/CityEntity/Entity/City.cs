using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions;
using VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Entity;

namespace VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;

public class City : BaseEntity
{
    private City() { }

    public City(string name, int cityCode, int provinceCode ,int provinceId)
    {
        Name = name;
        CityCode = cityCode;
        ProvinceCode = provinceCode;
        ProvinceId = provinceId;

        Validate();
    }

    public string Name { get; private set; }

    public int CityCode { get; private set; }

    public int ProvinceCode { get; private set; }

    //Foreign Key
    public int ProvinceId { get; set; }

    //Navigatio Properties
    public virtual Province Province { get; private set; }

    public virtual ICollection<Center> Centers { get; private set; } = new List<Center>();

    protected override void Validate()
    {
        if (CityCode < 1)
            throw new DomainException(DomainErrors.InvalidCityCodeRange);

        if (ProvinceCode < 1)
            throw new DomainException(DomainErrors.InvalidCityProvinceCodeRange);

        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException(DomainErrors.CityNameIsRequired);

        if (Name.Length < 2 || Name.Length > 120)
            throw new DomainException(DomainErrors.InvalidCityNameLength);

        if (ProvinceId < 1)
            throw new DomainException(DomainErrors.InvalidCityProvinceIdRange);
    }
}
