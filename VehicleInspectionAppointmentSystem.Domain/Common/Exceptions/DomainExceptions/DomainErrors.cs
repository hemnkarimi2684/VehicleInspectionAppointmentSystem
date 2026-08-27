using VehicleInspectionAppointmentSystem.Domain.Common.ErrorModel;

namespace VehicleInspectionAppointmentSystem.Domain.Common.Exceptions.DomainExceptions;

public static class DomainErrors
{
    #region Appointment Errors
    public static Error InvalidAppointmentAmountRange => new Error("invalid amount! the amount cannot be negative", "appointment.invalid_amount");
    public static Error InvalidAppointmentVehicleIdRange => new Error("invalid vehicleId! cannot be negative", "appointment.invalid_vehicleId");
    public static Error InvalidAppointmentTimeSlotIdRange => new Error("invalid vehicleId! cannot be negative", "appointment.invalid_timeSlotId");
    #endregion

    #region Center Errors
    public static Error InvalidCenterCodeRange => new Error("invalid CenterCode!", "center.invalid_centerCode");
    public static Error CenterNameIsRequired => new Error("the center name cannot be null", "center.required_name");
    public static Error InvalidCenterNameLength => new Error("the center name length cannot be less than 2 or higher than 150", "center.invalid_name_length");
    public static Error CenterAddressIsRequired => new Error("the Address cannot be null", "center.required_address");
    public static Error InvalidCenterAddressLength => new Error("the Address length cannot be less than 2 or higher than 200", "center.invalid_address_length");
    public static Error InvalidDailyMaxCapacityRange => new Error("invalid DailyMaxCapacity! the DailyMaxCapacity cannot be less than 0 and higher than 20", "center.invalid_dailyMaxCapacity");
    public static Error InvalidCenterManagerNameLength => new Error("the center ManagerName length cannot be less than 2 or higher than 120", "center.required_managerName");
    public static Error CenterPhoneNumberIsRequired => new Error("phone number is required", "center.required_phoneNumber");
    public static Error InvalidCenterPhoneNumberLength => new Error("the phone number cannot be less or higher than 11 character", "center.invalid_phoneNumber_length");
    public static Error CenterPhoneNumberIsDigit => new Error("invalid phone number! the phone number must be number", "center.invalid_phoneNumber_format");
    public static Error InvalidCenterCityIdRange => new Error("invalid CityId range!", "center.invalid_cityId");
    #endregion

    #region City Errors
    public static Error InvalidCityCodeRange => new Error("invalid CityCode range!", "city.invalid_cityId");
    public static Error InvalidCityProvinceCodeRange => new Error("invalid ProvinceCode range!", "city.invalid_provinceId");
    public static Error CityNameIsRequired => new Error("the city name cannot be null", "city.Required_cityName");
    public static Error InvalidCityNameLength => new Error("the name length cannot be less than 2 or higher than 120", "city.invalid_cityName_length");
    public static Error InvalidCityProvinceIdRange => new Error("invalid proviceId! the provice id cannot be negative", "city.invalid_provinceId");
    #endregion

    #region Province Errors
    public static Error InvalidProvinceCodeRange => new Error("invalid ProvinceCode!", "province.invalid_provinceCode");
    public static Error ProvinceNameIsRequired => new Error("the Province name cannot be null", "province.invalid_provinceName");
    public static Error InvalidProvinceNameLength => new Error("the name length cannot be less than 2 or higher than 150", "province.invalid_provinceName_length");
    #endregion

    #region TechnicalInspection Errors
    public static Error TechnicalInspectionDescriptionIsRequired => new Error("the Description cannot be null", "technicalInspection.required_description");
    public static Error InvalidTechnicalInspectionDescriptionLength => new Error("the Description length cannot be less than 2 or higher than 250", "technicalInspection.invalid_description_length");
    public static Error TechnicalInspectionIssueDateTimeRange => new Error("invalid IssueDate!", "technicalInspection.inavlid_issueDate");
    public static Error TechnicalInspectionExpireDateTimeRange => new Error("invalid ExpireDate", "technicalInspection.invalid_expireDate");
    public static Error InvalidTechnicalInspectionVehicleIdRange => new Error("invalid VehicleId! the AppointmentId cannot be negative", "technicalInspection.invalid_vehicleId");
    public static Error TechnicalInspectionVehicleVinIsRequired => new Error("the vin cannot be null", "technicalInspection.required_vehicleVin");
    public static Error TechnicalInspectionVehicleVinHasSymbol => new Error("invalid vin! vin have symbol", "technicalInspection.invalid_vehicleVin_format");
    public static Error InvalidTechnicalInspectionVehicleVinLength => new Error("invalid vin! the vin length must be 17", "technicalInspection.invalid_vehicleVin_length");
    public static Error TechnicalInspectionVehiclePlateIsRequired => new Error("the Plate cannot be null", "technicalInspection.required_vehiclePlate");
    public static Error InvalidTechnicalInspectionVehiclePlateLength => new Error("the Plate length must be 8 characters!", "technicalInspection.invalid_vehiclePlate_length");
    public static Error InvalidTechnicalInspectionVehiclePlateFormat => new Error("the Plate must have one letter in between the numbers like 11 .. 111 11", "technicalInspection.invalid_vehiclePlate_format");
    public static Error TechnicalInspectionVehiclePlateDontHaveDigit => new Error("the Plate must have numbers like 11 .. 111 11", "technicalInspection.invalid_vehiclePlate_format");
    public static Error TechnicalInspectionVehiclePlateHasSymbol => new Error("invalid plate! plate have symbol", "technicalInspection.invalid_vehiclePlate_format");
    public static Error InvalidTechnicalInspectionAppointmentIdRange => new Error("invalid AppointmentId! the AppointmentId cannot be negative", "technicalInspection.invalid_appointmentId");
    #endregion

    #region TiemSlot Errors
    public static Error InvalidTiemSlotDateTimeRange => new Error("invalid TimeSlotDate of Time Slot! the reserved date cannot be in the past", "timeSlot.invalid_timeSlotDate");
    public static Error InvalidTiemSlotStartTimeRange => new Error("Invalid start time. Allowed hours are between 01:00 and 18:00, and minutes must be either 00 or 30.", "timeSlot.invalid_startHour");
    public static Error InvalidTimeSLotCenterIdRange => new Error("invalid centerId input! the center id cannot be negative", "timeSlot.invalid_centerId");
    public static Error InvalidTimeSlotCapacityRange => new Error("invalid Capacity input! the Capacity cannot be negative", "timeSlot.invalid_capacity");
    #endregion

    #region User Errors
    public static Error InvalidUserFirstNameOrLastNameLength => new Error("Your first name or last name cannot be higer than 120 characters or less than 0.", "user.invalid_firstName_lastName_length");
    public static Error InvalidUserFatherNameLength => new Error("Your father name cannot be higer than 120 characters or less than 0.", "user.invalid_fatherName_length");
    public static Error UserPhoneNumberIsRequired => new Error("your phone number cannot be null or empty", "user.required_phoneNumber");
    public static Error InvalidUserPhoneNumberLength => new Error("the phone number cannot be less or higher than 11 character", "user.invalid_phoneNumber_length");
    public static Error UserPhoneNumberIsDigit => new Error("Your first name or last name cannot be higer than 120 characters or less than 0.", "user.invalid_phoneNumber_format");
    public static Error InvalidUserBirthDateRange => new Error("invalid age! you must be Adult", "user.invalid_birthDate");
    public static Error UserNationalCodeIsRequired => new Error("your NationalCode cannot be null or empty", "user.required_nationalCode");
    public static Error InvalidUserNationalCodeLength => new Error("the national code length is less or higher than 10 characters", "user.invalid_nationalCode_length");
    public static Error UserNationalCodeDontHaveDigit => new Error("for thee national code all characters must be digit", "user.invalid_nationalCode_format");
    public static Error UserNameIsRequired => new Error("Your user nam cannot be empty", "user.required_userName");
    public static Error InvalidUserNameLength => new Error("Your user name must be at least 3 characters long or Shorter than 20 characters.", "user.invalid_userName_length");
    public static Error UserNameHasSymbol => new Error("the user name cannot have any symbol", "user.invalid_userName_format");
    public static Error PasswordCannotEqualsWithUserName => new Error("the password cannot be equals with userName", "user.invalid_password");
    public static Error PasswordDontHaveAtLeastUpperCaseLetter => new Error("the password must have one upperCase letter", "user.invalid_password_lowerCase");
    public static Error PasswordDontHaveAtLeastLowerCaseLetter => new Error("the password must have one LowerCase letter", "user.invalid_password_UpperCase");
    public static Error PasswordDontHaveAtLeastOneDigit => new Error("the password must have one digit at least", "user.invalid_password_digit");
    public static Error PasswordDontHaveAtLeastOneSymbol => new Error("the password must have one symbol at least", "user.invalid_password_symbol");
    #endregion

    #region Vehicle Errors
    public static Error VehicleNameIsRequired => new Error("the vehicle name cannot be null", "vehicle.required_name");
    public static Error InvalidVehicleNameLength => new Error("the vehicle name length cannot be less than 2 or higher than 100", "vehicle.required_name");
    public static Error VehicleVinIsRequired => new Error("the vin cannot be null", "vehicle.required_vin");
    public static Error VehicleVinHasSymbol => new Error("invalid vin! vin have symbol", "vehicle.invalid_vin_format");
    public static Error InvalidVehicleVinLength => new Error("invalid vin! the vin length must be 17", "vehicle.invalid_vin_length");
    public static Error VehiclePlateIsRequired => new Error("the Plate cannot be null", "vehicle.required_plate");
    public static Error InvalidVehiclePlateLength => new Error("the Plate length must be 8 characters!", "vehicle.invalid_plate_length");
    public static Error InvalidVehiclePlateFormat => new Error("the Plate must have one letter in between the numbers like 11 .. 111 11", "vehicle.invalid_plate_format");
    public static Error VehiclePlateDontHaveDigit => new Error("the Plate must have numbers like 11 .. 111 11", "vehicle.invalid_plate_format");
    public static Error VehiclePlateHasSymbol => new Error("invalid plate! plate have symbol", "vehicle.invalid_plate_format");
    public static Error VehicleBrandIsRequired => new Error("the brand name cannot be null", "vehicle.required_brand");
    public static Error InvalidVehicleBrandLength => new Error("the brand name length cannot be less than 2 or higher than 120", "vehicle.invalid_brand_length");
    public static Error InvalidVehicleColorLength => new Error("the brand name length cannot be less than 1 or higher than 100", "vehicle.invalid_color_length");
    public static Error InvalidVehicleProductionYear => new Error("invalid production year!", "vehicle.invalid_productionYear");
    public static Error VehicleManufacturerCompanyIsRequired => new Error("the ManufacturerCompany cannot be null", "vehicle.required_manufacturerCompany");
    public static Error InvalidVehicleManufacturerCompanyLength => new Error("the ManufacturerCompany cannot be less than 2 or higher than 150", "vehicle.invalid_manufacturerCompany_length");
    public static Error InvalidVehicleUserIdRange => new Error("invalid userId! the user id cannot be negative", "vehicle.invalid_userId");
    #endregion
}
