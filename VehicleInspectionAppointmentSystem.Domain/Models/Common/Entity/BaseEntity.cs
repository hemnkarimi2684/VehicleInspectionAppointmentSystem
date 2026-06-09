namespace VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;

public abstract class BaseEntity
{
    public int Id { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? UpdatedAt { get; private set; }

    public bool IsDeleted { get; private set; } 

    public DateTime? DeletedAt { get; private set; }

    protected abstract void Validate();

    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
