using System.Security.AccessControl;
using VehicleInspectionAppointmentSystem.Contracts.RequestDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Contracts.ResponseDto.AppointmentDto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TechnicalInspectionEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Service;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Service;

namespace VehicleInspectionAppointmentSystem.Business.Businesses.AppointmentBusiness;

public class ApointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    private readonly ITimeSlotService _timeSlotService;

    private readonly IVehicleService _vehicleService;

    public ApointmentService(IAppointmentRepository appointmentRepository, ITimeSlotService timeSlotService, IVehicleService vehicleService)
    {
        _appointmentRepository = appointmentRepository;
        _timeSlotService = timeSlotService;
        _vehicleService = vehicleService;
    }

    public async Task<bool> CheckAppointmentStatusIsDoneAsync(int appointmentId) => await _appointmentRepository.CheckAppointmentStatusIsDoneAsync(appointmentId);

    public async Task<bool> CreateAppointmentAsync(AppointmentCreateRequestDto appointmentCreate)
    {
        await _vehicleService.IsVehicleExistAsync(appointmentCreate.VehicleId);

        await _timeSlotService.IsExistTimeSlotAsync(appointmentCreate.TimeSlotId);

        var hasActiveAppointment = await HasActiveAppointmentAsync(appointmentCreate.VehicleId);

        if (hasActiveAppointment)
            throw new ArgumentException("Dear user you have appointment already with this vehicle!");

        //this must be chack after learning authentication add this method 
        //await _vehicleService.IsCarOwnedByUserAsync(appointmentCreate.vehicleId,appointmentCrea)

        await _timeSlotService.CheckTimeSlotIsReservedAsync(appointmentCreate.TimeSlotId);

        if (!Enum.TryParse<Status>(appointmentCreate.Status, true, out var appointmentStatus))
            throw new InvalidOperationException("something went wrong with parse of status enum");

        if (!Enum.TryParse<PaymentType>(appointmentCreate.PaymentType, true, out var appointmentPaymentType))
            throw new InvalidOperationException("something went wrong with parse of payment type enum");

        var newAppointment = new Appointment(appointmentStatus, appointmentCreate.Amount, appointmentPaymentType, appointmentCreate.VehicleId, appointmentCreate.TimeSlotId);

        var result = await _appointmentRepository.AddAsync(newAppointment);

        if (!result)
            throw new ArgumentException("something went wrong in add appointment please try later!");

        await _timeSlotService.UpdateAppointmentReservedStatusAsync(newAppointment.TimeSlotId, true);
        return true;
    }

    public async Task<List<AppointmentDetailsResponseDto>> GetAllWithPaginationAsync(int page, int pageSize)
    {
        var appointments = await _appointmentRepository.QueryAsync(a => new AppointmentDetailsResponseDto
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
            throw new ArgumentException("We do not have any appointments");

        return appointments;
    }

    public async Task<List<AppointmentDetailsResponseDto>> GetVehicleAppointmentsAsync(int vehicleId)
    {
        var vehiclAppointments = await _appointmentRepository.GetVehicleAppointmentsAsync(a => new AppointmentDetailsResponseDto
        (
            a.Id,
            a.Status.ToString(),
            a.Amount,
            a.VehicleId,
            a.Vehicle.Plate,
            a.TimeSlot.StartTime,
            a.TimeSlot.EndTime,
            a.TimeSlot.TimeSlotDate
        ), vehicleId);

        if (vehiclAppointments == null || !vehiclAppointments.Any())
            throw new ArgumentException("We do not have any appointments for this vehicle");

        return vehiclAppointments;
    }

    public async Task<bool> HasActiveAppointmentAsync(int vehicleId) => await _appointmentRepository.HasActiveAppointmentAsync(vehicleId);

    public async Task<bool> HasActiveAppointmentAtTimeAsync(int vehicleId, int timeSlotId)
    {
        var hasActiveAppointmentAtTime = await _appointmentRepository.HasActiveAppointmentAtTimeAsync(vehicleId, timeSlotId);

        if (hasActiveAppointmentAtTime)
            throw new ArgumentException("Dear user you have appointment at time already with this vehicle!");

        return hasActiveAppointmentAtTime;
    }

    public async Task<bool> HasActiveAppointmentBelongToVehicleAsync(int vehicleId, int appointmentId)
    {
        var hasActiveAppointmentBelongToVehicle = await _appointmentRepository.HasActiveAppointmentBelongToVehicleAsync(vehicleId, appointmentId);

        if (!hasActiveAppointmentBelongToVehicle)
            throw new ArgumentException("this appointment not blong to this vehicle or not found or not active");

        return hasActiveAppointmentBelongToVehicle;
    }
}

