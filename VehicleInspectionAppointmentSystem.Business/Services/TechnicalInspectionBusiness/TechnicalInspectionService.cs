using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TechnicalInspectionBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Business.RequestDto.TechnicalInspectionDto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Enums;

namespace VehicleInspectionAppointmentSystem.Business.Services.TechnicalInspectionBusiness;

public class TechnicalInspectionService : ITechnicalInspectionService
{
    private readonly ITechnicalInspectionRepository _technicalInspectionRepository;

    private readonly IVehicleService _vehicleService;

    private readonly IAppointmentService _appointmentService;

    public TechnicalInspectionService(ITechnicalInspectionRepository technicalInspectionRepository, IVehicleService vehicleService, IAppointmentService appointmentService)
    {
        _technicalInspectionRepository = technicalInspectionRepository;
        _vehicleService = vehicleService;
        _appointmentService = appointmentService;
    }

    public async Task<bool> CraeteTechnicalInspectionAsync(TechnicalInspectionCreateRequestDto inspectionCreateDto)
    {
        var checkAppointmentStatusIsDoneAsync = await _appointmentService.CheckAppointmentStatusIsDoneAsync(inspectionCreateDto.AppointmentId);

        if (!checkAppointmentStatusIsDoneAsync)
            throw new ValidationException("Dear you not have any done appointment for this vehicle!");

        await _appointmentService.HasActiveAppointmentBelongToVehicleAsync(inspectionCreateDto.VehicleId, inspectionCreateDto.AppointmentId);

        var vehicleHasTechnicalInspection = await _technicalInspectionRepository.VehicleHasTechnicalInspectionAsync(inspectionCreateDto.VehicleId);

        if (vehicleHasTechnicalInspection)
            throw new ConflictException("this vehicle has TechnicalInspection already!");

        if (!Enum.TryParse<Result>(inspectionCreateDto.Result, true, out var technicalInspectionResult))
            throw new ValidationException("something went wrong with parse of technical Inspection Result enum");

        var vehicleOfTechnicalInspection = await _vehicleService.GetByIdAsync(inspectionCreateDto.VehicleId);

        var newTechnicalInspection = new TechnicalInspection(technicalInspectionResult, inspectionCreateDto.Description, inspectionCreateDto.IssueDate,
                   vehicleOfTechnicalInspection.Plate, vehicleOfTechnicalInspection.Vin, vehicleOfTechnicalInspection.Id, inspectionCreateDto.AppointmentId);

        return await _technicalInspectionRepository.AddAsync(newTechnicalInspection);
    }

    public async Task<List<TechnicalInspectionResponseDto>> GetAllWithPaginationAsync(int page = 1, int pageSize = 10)
    {
        var technicalInspections = await _technicalInspectionRepository.QueryAsync(ti => new TechnicalInspectionResponseDto
        (
            ti.Description,
            ti.IssueDate,
            ti.ExpireDate,
            ti.VehiclePlate,
            ti.VehicleVin
        ), page, pageSize);


        if (technicalInspections == null || !technicalInspections.Any())
            throw new NotFoundException("We do not have any technicalInspections");

        return technicalInspections;
    }

    public async Task<List<TechnicalInspectionResponseDto>> GetVehicleTechnicalInspectionAsync(int vehicleId)
    {
        var vehicleTechnicalInspections = await _technicalInspectionRepository.GetVehicleTechnicalInspectionAsync(vehicleId);


        if (vehicleTechnicalInspections == null || !vehicleTechnicalInspections.Any())
            throw new NotFoundException($"We do not have any technicalInspections for this vehicle {vehicleId}");

        return vehicleTechnicalInspections;
    }
}
