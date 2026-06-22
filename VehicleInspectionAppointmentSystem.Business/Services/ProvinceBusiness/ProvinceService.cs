using VehicleInspectionAppointmentSystem.Business.Interfaces.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.ProvinceBusiness;

public class ProvinceService : IProvinceService 
{
    private readonly IProvinceRepository _provinceRepository;

    public ProvinceService(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<List<ProvinceResponseDto>> GetAllProvinceAsync()
    {
        var provices = await _provinceRepository.QueryAsync(p => new ProvinceResponseDto
        (
            p.Id,
            p.Name,
            p.ProvinceCode
        ));

        if (provices == null || !provices.Any())
            throw new ArgumentException("Dear user you dont have any provice in the system!");

        return provices;
    }
}
