using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.AppointmentRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CenterRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CityRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.ProvinceRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TechnicalInspectionRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TimeSlotRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.UserRepo;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.VehicleRepo;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        AppointmentRepository = new AppointmentRepository(_context);
        CenterRepository = new CenterRepositoy(_context);
        CityRepository = new CityRepository(_context);
        ProvinceRepository = new ProvinceRepository(_context);
        TechnicalInspectionRepository = new TechnicalInspectionRepository(_context);
        TimeSlotRepository = new TimeSlotRepository(_context);
        UserRepository = new UserRepository(_context);
        VehicleRepository = new VehicleRepository(_context);
    }

    public IAppointmentRepository AppointmentRepository { get; }

    public ICenterRepository CenterRepository { get; }

    public ICityRepository CityRepository { get; }

    public IProvinceRepository ProvinceRepository { get; }

    public ITechnicalInspectionRepository TechnicalInspectionRepository { get; }

    public ITimeSlotRepository TimeSlotRepository { get; }

    public IUserRepository UserRepository { get; }

    public IVehicleRepository VehicleRepository { get; }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
    {
        var type = typeof(T);

        if (!_repositories.ContainsKey(type))
        {
            var repoistory = new GenericRepository<T>(_context);

            _repositories.Add(type, repoistory);
        }

        return (IGenericRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
