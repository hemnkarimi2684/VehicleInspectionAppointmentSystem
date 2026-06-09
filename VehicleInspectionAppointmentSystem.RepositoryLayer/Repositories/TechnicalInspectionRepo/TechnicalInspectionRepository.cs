using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TechnicalInspectionRepo;

public class TechnicalInspectionRepository : GenericRepository<TechnicalInspection>, ITechnicalInspectionRepository
{
    public TechnicalInspectionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TResult>> GetVehicleTechnicalInspectionAsync<TResult>(Expression<Func<TechnicalInspection, TResult>> selector, int vehicleId)
    {
        return await Entities
                           .AsNoTracking()
                           .Where(ti => ti.VehicleId == vehicleId)
                           .Select(selector)
                           .ToListAsync();
    }

    public async Task<bool> VehicleHasTechnicalInspectionAsync(int vehicleId) => await AnyAsync(ti => ti.VehicleId == vehicleId && ti.Result == Result.Active);

}
