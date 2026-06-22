using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.CityEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.CityRepo;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<CityResponseDto>> GetCitiesByProvinceIdAsync(int provinceId)
    {
        return await Entities
                          .AsNoTracking()
                          .Where(c => c.ProvinceId == provinceId)
                          .Select(c => new CityResponseDto
                          (
                              c.Id,
                              c.Name,
                              c.CityCode,
                              c.ProvinceCode
                          ))
                          .ToListAsync();
    }
}
