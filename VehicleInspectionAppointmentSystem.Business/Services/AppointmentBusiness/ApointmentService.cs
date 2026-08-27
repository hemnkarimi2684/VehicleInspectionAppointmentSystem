using VehicleInspectionAppointmentSystem.Business.Common.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.AppointmentBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.TimeSlotBusiness;
using VehicleInspectionAppointmentSystem.Business.Interfaces.VehicleBusiness;
using VehicleInspectionAppointmentSystem.Business.RequestDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;


namespace VehicleInspectionAppointmentSystem.Business.Services.AppointmentBusiness;

public class ApointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITimeSlotService _timeSlotService;

    private readonly IVehicleService _vehicleService;

    public ApointmentService(IUnitOfWork unitOfWork, ITimeSlotService timeSlotService, IVehicleService vehicleService)
    {
        _unitOfWork = unitOfWork;
        _timeSlotService = timeSlotService;
        _vehicleService = vehicleService;
    }

    public async Task<bool> CheckAppointmentStatusIsDoneAsync(int appointmentId) => await _unitOfWork.AppointmentRepository.CheckAppointmentStatusIsDoneAsync(appointmentId);

    public async Task<bool> CreateAppointmentAsync(AppointmentCreateRequestDto appointmentCreate)
    {
        await _vehicleService.IsVehicleExistAsync(appointmentCreate.VehicleId);

        await _timeSlotService.IsExistTimeSlotAsync(appointmentCreate.TimeSlotId);

        var hasActiveAppointment = await HasActiveAppointmentAsync(appointmentCreate.VehicleId);

        if (hasActiveAppointment)
            throw new ConflictException("Dear user you have appointment already with this vehicle!");

        //this must be chack after learning authentication add this method 
        //await _vehicleService.IsCarOwnedByUserAsync(appointmentCreate.vehicleId,appointmentCrea)

        await _timeSlotService.CheckTimeSlotIsReservedAsync(appointmentCreate.TimeSlotId);

        if (!Enum.TryParse<Status>(appointmentCreate.Status, true, out var appointmentStatus))
            throw new ValidationException("something went wrong with parse of status enum");

        if (!Enum.TryParse<PaymentType>(appointmentCreate.PaymentType, true, out var appointmentPaymentType))
            throw new ValidationException("something went wrong with parse of payment type enum");

        var newAppointment = new Appointment(appointmentStatus, appointmentCreate.Amount, appointmentPaymentType, appointmentCreate.VehicleId, appointmentCreate.TimeSlotId);

        var result = await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);

        if (!result)
            throw new ValidationException("something went wrong in add appointment please try later!");

        await _timeSlotService.UpdateAppointmentReservedStatusAsync(newAppointment.TimeSlotId, true);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<List<AppointmentDetailsResponseDto>> GetAllWithPaginationAsync(int page, int pageSize)
    {
        var appointments = await _unitOfWork.AppointmentRepository.QueryAsync(a => new AppointmentDetailsResponseDto
        (
            a.Id,
            a.Status.ToString(),
            a.Amount,
            a.VehicleId,
            a.Vehicle.Plate,
            a.TimeSlot.StartTime,
            a.TimeSlot.EndTime,
            a.TimeSlot.TimeSlotDate
        ), page, pageSize);

        if (appointments == null || !appointments.Any())
            throw new NotFoundException("We do not have any appointments");

        return appointments;
    }

    public async Task<List<AppointmentDetailsResponseDto>> GetVehicleAppointmentsAsync(int vehicleId)
    {
        var vehiclAppointments = await _unitOfWork.AppointmentRepository.GetVehicleAppointmentsAsync(vehicleId);

        if (vehiclAppointments == null || !vehiclAppointments.Any())
            throw new NotFoundException("We do not have any appointments for this vehicle");

        return vehiclAppointments;
    }

    public async Task<bool> HasActiveAppointmentAsync(int vehicleId) => await _unitOfWork.AppointmentRepository.HasActiveAppointmentAsync(vehicleId);

    public async Task<bool> HasActiveAppointmentAtTimeAsync(int vehicleId, int timeSlotId)
    {
        var hasActiveAppointmentAtTime = await _unitOfWork.AppointmentRepository.HasActiveAppointmentAtTimeAsync(vehicleId, timeSlotId);

        if (hasActiveAppointmentAtTime)
            throw new ConflictException("Dear user you have appointment at time already with this vehicle!");

        return hasActiveAppointmentAtTime;
    }

    public async Task<bool> HasActiveAppointmentBelongToVehicleAsync(int vehicleId, int appointmentId)
    {
        var hasActiveAppointmentBelongToVehicle = await _unitOfWork.AppointmentRepository.HasActiveAppointmentBelongToVehicleAsync(vehicleId, appointmentId);

        if (!hasActiveAppointmentBelongToVehicle)
            throw new ForbiddenException("this appointment not blong to this vehicle or not found or not active");

        return hasActiveAppointmentBelongToVehicle;
    }
}

