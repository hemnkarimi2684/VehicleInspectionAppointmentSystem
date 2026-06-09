using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.VehicleRepo;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TResult>> GetUserVehiclesAsync<TResult>(Expression<Func<Vehicle,TResult>> selector,int userId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(v => v.UserId == userId && v.IsActive)
                          .Select(selector)
                          .ToListAsync();
    }

    public async Task<bool> IsCarOwnedByUserAsync(int vehicleId, int userId) => await AnyAsync(v => v.Id == vehicleId && v.UserId == userId && v.IsActive);

    public async Task<bool> IsVehicleExistAsync(int vehicleId) => await AnyAsync(v => v.Id == vehicleId && v.IsActive);

}
