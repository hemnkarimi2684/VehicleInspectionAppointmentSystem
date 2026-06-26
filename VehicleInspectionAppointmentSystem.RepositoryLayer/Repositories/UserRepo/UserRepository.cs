using Microsoft.EntityFrameworkCore;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Common;
using VehicleInspectionAppointmentSystem.RepositoryLayer.Common;

namespace VehicleInspectionAppointmentSystem.RepositoryLayer.Repositories.UserRepo;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AnyUserWithThisPhoneNumberAsync(string phoneNumber) => await AnyAsync(x => x.PhoneNumber == phoneNumber);

    public async Task<bool> AnyUserWithThisUserNameAsync(string userName) => await AnyAsync(u => u.UserName == userName);

    public async Task<bool> CheckUserHasPasswordAsync(int userId) => await AnyAsync(u => u.Id == userId && u.Password != null);

    public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber) => await Entities.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

    public async Task<User?> GetUserByUserNameAsync(string userName) => await Entities.FirstOrDefaultAsync(u => u.UserName == userName);

    public async Task<bool> UpdateCredentialsAsync(int userId, string userName, string password)
    {
        var user = await Entities.FindAsync(userId);

        if (user == null)
            return false;

        user.UpdatePasswordAndUserName(userName, password);

        return await DbContext.SaveChangesAsync() > 0;
    }
}

