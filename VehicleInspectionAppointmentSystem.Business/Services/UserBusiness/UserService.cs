using VehicleInspectionAppointmentSystem.Business.Exceptions.ApplicationExceptions;
using VehicleInspectionAppointmentSystem.Business.Interfaces.UserBusiness;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Data;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Dto;

namespace VehicleInspectionAppointmentSystem.Business.Services.UserBusiness;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> AnyUserWithThisPhoneNumberAsync(string phoneNumber)
    {
        var result = await _unitOfWork.UserRepository .AnyUserWithThisPhoneNumberAsync(phoneNumber);

        if (result)
            throw new NotFoundException("this phone number is already exist in system");

        return result;
    }

    public async Task<bool> AnyUserWithThisUserNameAsync(string userName)
    {
        var result = await _unitOfWork.UserRepository.AnyUserWithThisUserNameAsync(userName);

        if (result)
            throw new ConflictException("this user name is already exist in system");

        return result;
    }

    public async Task<bool> CheckUserHasPasswordAsync(int userId)
    {
        var result = await _unitOfWork.UserRepository.CheckUserHasPasswordAsync(userId);

        if (result)
            throw new ConflictException("this user has password");

        return result;
    }

    public async Task<UserResponseDto> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        var foundedUser = await _unitOfWork.UserRepository .GetUserByPhoneNumberAsync(phoneNumber);

        if (foundedUser is null)
            throw new NotFoundException($"the user with this phone number {phoneNumber} not exist");

        return new UserResponseDto
        (
           foundedUser.Id,
           foundedUser.FirstName,
           foundedUser.LastName,
           foundedUser.NationalCode,
           foundedUser.FatherName,
           foundedUser.PhoneNumber,
           foundedUser.BirthDate
        );
    }

    public async Task<UserResponseDto> GetUserByUserNameAsync(string userName)
    {
        var foundedUser = await _unitOfWork.UserRepository.GetUserByUserNameAsync(userName);

        if (foundedUser is null)
            throw new NotFoundException($"the user with this user name {userName} not exist");

        return new UserResponseDto
        (
           foundedUser.Id,
           foundedUser.FirstName,
           foundedUser.LastName,
           foundedUser.NationalCode,
           foundedUser.FatherName,
           foundedUser.PhoneNumber,
           foundedUser.BirthDate
        );
    }

    public async Task<bool> UpdateCredentialsAsync(int userId, string userName, string password)
    {
        var result = await _unitOfWork.UserRepository.UpdateCredentialsAsync(userId, userName, password);

        if (!result)
            throw new ValidationException("somthing goes wrong in update user user name and password");

        return result;
    }
}
