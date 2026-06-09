using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.AppointmentEntity.Enums;
using VehicleInspectionAppointmentSystem.Domain.Models.Appointments.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.TimeSlotEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.VehicleEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.CommonRepository;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.AppointmentRepo;

public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckAppointmentStatusIsDoneAsync(int appointmentId) => await AnyAsync(a => a.Id == appointmentId && a.Status == Status.Done);

    public async Task<List<TResult>> GetVehicleAppointmentsAsync<TResult>(Expression<Func<Appointment, TResult>> selector,int vehicleId)
    {
        return await Entities
                           .AsNoTracking()
                           .Where(a => a.VehicleId == vehicleId)
                           .Select(selector)
                           .ToListAsync();
    }

    public async Task<bool> HasActiveAppointmentAsync(int vehicleId) => await AnyAsync(a => a.VehicleId == vehicleId && a.Status == Status.Active);

    public async Task<bool> HasActiveAppointmentAtTimeAsync(int vehicleId, int timeSlotId) => await AnyAsync(a => a.VehicleId == vehicleId && a.TimeSlotId == timeSlotId && a.Status == Status.Active);

    public async Task<bool> HasActiveAppointmentBelongToVehicleAsync(int vehicleId, int appointmentId) => await AnyAsync(a => a.Id == appointmentId && a.VehicleId == vehicleId && a.Status == Status.Active);

}
