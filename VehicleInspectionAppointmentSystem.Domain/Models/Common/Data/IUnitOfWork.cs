using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;

namespace VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;

public interface IUnitOfWork
{
    IGenericRepository<T> GetRepository<T>() where T : BaseEntity;

    IAppointmentRepository AppointmentRepository { get; }

    ICenterRepository CenterRepository { get; }

    ICityRepository CityRepository { get; }

    IProvinceRepository ProvinceRepository { get; }

    ITechnicalInspectionRepository TechnicalInspectionRepository { get; }

    ITimeSlotRepository TimeSlotRepository { get; }

    IUserRepository UserRepository { get; }

    IVehicleRepository VehicleRepository { get; }

    Task<int> SaveChangesAsync();
}
