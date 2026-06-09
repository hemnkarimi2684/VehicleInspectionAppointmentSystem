using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.CenterEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CenterRepo;

public class CenterRepositoy : GenericRepository<Center>, ICenterRepository
{
    public CenterRepositoy(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CanAddTimeSlotForDayAsync(int centerId, DateTime timeSlotDate) => await AnyAsync(c => c.Id == centerId && c.DailyMaxCapacity >= c.TimeSlots.Count(ts => ts.TimeSlotDate == timeSlotDate));

    public async Task<List<TResult>> GetActiveCentersOfCityAsync<TResult>(Expression<Func<Center, TResult>> selector, int cityId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(c => c.CityId == cityId)
                          .Select(selector)
                          .ToListAsync();
    }
}
