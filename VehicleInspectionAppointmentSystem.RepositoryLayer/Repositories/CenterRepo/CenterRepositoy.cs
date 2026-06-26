using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CenterRepo;

public class CenterRepositoy : GenericRepository<Center>, ICenterRepository
{
    public CenterRepositoy(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CanAddTimeSlotForDayAsync(int centerId, DateTime timeSlotDate) => await AnyAsync(c => c.Id == centerId && c.DailyMaxCapacity >= c.TimeSlots.Count(ts => ts.TimeSlotDate == timeSlotDate));

    public async Task<List<CenterResponseDto>> GetActiveCentersOfCityAsync(int cityId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(c => c.CityId == cityId)
                          .Select(c => new CenterResponseDto
                          (
                              c.Id,
                              c.CenterCode,
                              c.Name,
                              c.Address,
                              c.PhoneNumber
                          ))
                          .ToListAsync();
    }
}
