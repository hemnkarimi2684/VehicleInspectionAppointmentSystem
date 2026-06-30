namespace VehicleInspectionAppointmentSystem.Business.CacheKeys;

public static class RedisKeys
{
    public static string GetCenterTimeSLots(int centerId) => $"Center:{centerId}:TimeSlots";

}
