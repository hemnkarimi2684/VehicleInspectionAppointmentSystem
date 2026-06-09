using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.Centers.Entity;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.CenterConfiguration;

public class CenterModelBuilderConfiguration : BaseModelBuilderConfiguration<Center>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Center> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(c => c.CenterCode)
            .IsUnique();

        builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.DailyMaxCapacity)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(c => c.ManagerName)
            .HasMaxLength(120);

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasMany(c => c.TimeSlots)
            .WithOne(t => t.Center)
            .HasForeignKey(t => t.CenterId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasData(
        new
        {
            Id = 1,
            CenterCode = 1001,
            Name = "North Tehran Technical Inspection Center",
            Address = "No. 15, Shariati Street, Tehran",
            DailyMaxCapacity = 20,
            ManagerName = "Michael Anderson",
            PhoneNumber = "09121001001",
            CityId = 1
        },
        new
        {
            Id = 2,
            CenterCode = 1002,
            Name = "West Tehran Vehicle Inspection Center",
            Address = "No. 42, Azadi Avenue, Tehran",
            DailyMaxCapacity = 18,
            ManagerName = "Daniel Brown",
            PhoneNumber = "09121001002",
            CityId = 1
        },
        new
        {
            Id = 3,
            CenterCode = 1003,
            Name = "Rey Central Inspection Center",
            Address = "No. 8, Imam Street, Rey",
            DailyMaxCapacity = 15,
            ManagerName = "Robert Wilson",
            PhoneNumber = "09121001003",
            CityId = 2
        },
        new
        {
            Id = 4,
            CenterCode = 2001,
            Name = "Isfahan Main Inspection Center",
            Address = "No. 22, Chaharbagh Avenue, Isfahan",
            DailyMaxCapacity = 20,
            ManagerName = "James Miller",
            PhoneNumber = "09121002001",
            CityId = 3
        },
        new
        {
            Id = 5,
            CenterCode = 2002,
            Name = "Kashan Vehicle Safety Center",
            Address = "No. 11, Fin Road, Kashan",
            DailyMaxCapacity = 14,
            ManagerName = "William Davis",
            PhoneNumber = "09121002002",
            CityId = 4
        },
        new
        {
            Id = 6,
            CenterCode = 3001,
            Name = "Shiraz Central Technical Inspection",
            Address = "No. 31, Zand Boulevard, Shiraz",
            DailyMaxCapacity = 20,
            ManagerName = "Thomas Moore",
            PhoneNumber = "09121003001",
            CityId = 5
        },
        new
        {
            Id = 7,
            CenterCode = 3002,
            Name = "Marvdasht Vehicle Inspection Station",
            Address = "No. 19, Persepolis Road, Marvdasht",
            DailyMaxCapacity = 12,
            ManagerName = "Christopher Taylor",
            PhoneNumber = "09121003002",
            CityId = 6
        },
        new
        {
            Id = 8,
            CenterCode = 4001,
            Name = "Mashhad East Inspection Center",
            Address = "No. 61, Vakilabad Boulevard, Mashhad",
            DailyMaxCapacity = 19,
            ManagerName = "Matthew Clark",
            PhoneNumber = "09121004001",
            CityId = 7
        },
        new
        {
            Id = 9,
            CenterCode = 4002,
            Name = "Neyshabur Technical Inspection Center",
            Address = "No. 5, Attar Street, Neyshabur",
            DailyMaxCapacity = 13,
            ManagerName = "Anthony Lewis",
            PhoneNumber = "09121004002",
            CityId = 8
        },
        new
        {
            Id = 10,
            CenterCode = 5001,
            Name = "Tabriz Main Vehicle Inspection Center",
            Address = "No. 77, Elgoli Road, Tabriz",
            DailyMaxCapacity = 20,
            ManagerName = "Mark Walker",
            PhoneNumber = "09121005001",
            CityId = 9
        },
        new
        {
            Id = 11,
            CenterCode = 5002,
            Name = "Maragheh Road Safety Inspection Center",
            Address = "No. 14, Sahand Avenue, Maragheh",
            DailyMaxCapacity = 11,
            ManagerName = "Steven Hall",
            PhoneNumber = "09121005002",
            CityId = 10
        }
    );
    }
}
