using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.ProvinceBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.ProvinceEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.ProvinceBusiness;

public class ProvinceService : IProvinceService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProvinceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ProvinceResponseDto>> GetAllProvinceAsync()
    {
        var provices = await _unitOfWork.ProvinceRepository.QueryAsync(p => new ProvinceResponseDto
        (
            p.Id,
            p.Name,
            p.ProvinceCode
        ));

        if (provices == null || !provices.Any())
            throw new NotFoundException("Dear user you dont have any provice in the system!");

        return provices;
    }
}
