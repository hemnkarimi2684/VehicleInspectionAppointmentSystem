using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.TimeSlotRepo;

public class TimeSlotRepository : GenericRepository<TimeSlot>, ITimeSlotRepository
{
    public TimeSlotRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckTimeSlotIsReservedAsync(int timeSlotId) => await AnyAsync(ts => ts.Id == timeSlotId && ts.IsReserved);

    public async Task<List<TimeSlotResponseDto>> GetCenterAvailableTimeSlotsAsync(int centerId)
    {
        return await Entities
                            .AsNoTracking()
                            .Where(ts => ts.CenterId == centerId && !ts.IsReserved)
                            .Select(ts => new TimeSlotResponseDto
                            (
                                ts.Id,
                                ts.StartTime,
                                ts.EndTime,
                                ts.Capacity
                            ))
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
