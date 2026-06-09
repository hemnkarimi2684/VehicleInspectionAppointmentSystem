using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TimeSlotRepo;

public class TimeSlotRepository : GenericRepository<TimeSlot>, ITimeSlotRepository
{
    public TimeSlotRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckTimeSlotIsReservedAsync(int timeSlotId) => await AnyAsync(ts => ts.Id == timeSlotId && ts.IsReserved);

    public async Task<List<TResult>> GetCenterAvailableTimeSlotsAsync<TResult>(Expression<Func<TimeSlot, TResult>> selector, int centerId)
    {
        return await Entities
                            .AsNoTracking()
                            .Where(ts => ts.CenterId == centerId && !ts.IsReserved)
                            .Select(selector)
                            .ToListAsync();
    }

    public async Task<bool> IsExistTimeSlotAsync(int timeSlotId) => await AnyAsync(ts => ts.Id == timeSlotId);

    public async Task<bool> UpdateAppointmentReservedStatusAsync(int timeSlotId, bool isReserved)
    {
        var timeSlot = await Entities
                                    .FindAsync(timeSlotId);

        if (timeSlot is null)
            return false;

        timeSlot.UpdateReservedStatus(isReserved);

        return await DbContext.SaveChangesAsync() > 0;
    }
}
