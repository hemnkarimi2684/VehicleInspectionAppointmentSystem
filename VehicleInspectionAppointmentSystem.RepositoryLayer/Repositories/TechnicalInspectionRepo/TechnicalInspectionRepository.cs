using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TechnicalInspectionRepo;

public class TechnicalInspectionRepository : GenericRepository<TechnicalInspection>, ITechnicalInspectionRepository
{
    public TechnicalInspectionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TechnicalInspectionResponseDto>> GetVehicleTechnicalInspectionAsync(int vehicleId)
    {
        return await Entities
                           .AsNoTracking()
                           .Where(ti => ti.VehicleId == vehicleId)
                           .Select(ti => new TechnicalInspectionResponseDto
                           (
                               ti.Description,
                               ti.IssueDate,
                               ti.ExpireDate,
                               ti.VehiclePlate,
                               ti.VehicleVin
                           ))
                           .ToListAsync();
    }

    public async Task<bool> VehicleHasTechnicalInspectionAsync(int vehicleId) => await AnyAsync(ti => ti.VehicleId == vehicleId && ti.Result == Result.Active);

}
