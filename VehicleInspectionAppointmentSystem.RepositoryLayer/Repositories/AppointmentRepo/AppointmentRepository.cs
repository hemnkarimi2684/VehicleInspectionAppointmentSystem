using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Dto;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.AppointmentRepo;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckAppointmentStatusIsDoneAsync(int appointmentId) => 
                                                    await AnyAsync(a => a.Id == appointmentId && a.Status == Status.Done);

    public async Task<List<AppointmentDetailsResponseDto>> GetVehicleAppointmentsAsync(int vehicleId)
    {
        return await Entities
                           .AsNoTracking()
                           .Where(a => a.VehicleId == vehicleId)
                           .Select(a => new AppointmentDetailsResponseDto
                           (
                               a.Id,
                               a.Status.ToString(),
                               a.Amount,
                               a.VehicleId,
                               a.Vehicle.Plate,
                               a.TimeSlot.StartTime,
                               a.TimeSlot.EndTime,
                               a.TimeSlot.TimeSlotDate
                           ))
                           .ToListAsync();
    }

    public async Task<bool> HasActiveAppointmentAsync(int vehicleId) =>
                                        await AnyAsync(a => a.VehicleId == vehicleId && a.Status == Status.Active);

    public async Task<bool> HasActiveAppointmentAtTimeAsync(int vehicleId, int timeSlotId) =>
                                        await AnyAsync(a => a.VehicleId == vehicleId && a.TimeSlotId == timeSlotId && a.Status == Status.Active);

    public async Task<bool> HasActiveAppointmentBelongToVehicleAsync(int vehicleId, int appointmentId) => 
                                        await AnyAsync(a => a.Id == appointmentId && a.VehicleId == vehicleId && a.Status == Status.Active);

}
