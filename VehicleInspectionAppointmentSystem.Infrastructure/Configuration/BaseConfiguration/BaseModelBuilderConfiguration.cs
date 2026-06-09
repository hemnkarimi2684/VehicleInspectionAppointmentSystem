using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.Common.Entity;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

public abstract class BaseModelBuilderConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(b => b.Id);

        builder.HasIndex(b => b.CreatedAt);

        builder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(b => !b.IsDeleted && b.DeletedAt == null);

        ApplyEntityConfiguration(builder);

    }

    protected abstract void ApplyEntityConfiguration(EntityTypeBuilder<T> builder);
}
