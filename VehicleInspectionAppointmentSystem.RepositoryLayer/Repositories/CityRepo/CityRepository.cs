using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CityRepo;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<TResult>> GetCitiesByProvinceIdAsync<TResult>(Expression<Func<City, TResult>> selector, int provinceId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(c => c.ProvinceId == provinceId)
                          .Select(selector)
                          .ToListAsync();
    }
}
