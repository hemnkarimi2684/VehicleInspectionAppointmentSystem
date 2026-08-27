using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Entity;
using VehicleInspectionAppointmentSystem.Domain.Models.UserEntity.Enums;
using VehicleInspectionAppointmentSystem.Infrastructure.Configuration.BaseConfiguration;

namespace VehicleInspectionAppointmentSystem.Infrastructure.Configuration.UserConfiguration;

public class UserModelBuilderConfiguration : BaseModelBuilderConfiguration<User>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.FirstName)
            .HasMaxLength(120);

        builder.Property(u => u.LastName)
            .HasMaxLength(120);

        builder.Property(u => u.FatherName)
            .HasMaxLength(120);

        builder.Property(u => u.NationalCode)
            .HasMaxLength(10);

        builder.Property(u => u.UserName)
            .HasMaxLength(20);

        builder.Property<string>("_password")
            .HasColumnName("Password")
            .HasMaxLength(60);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasIndex(u => u.UserName)
            .IsUnique();

        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();

        builder.HasMany(u => u.Vehicles)
            .WithOne(v => v.User)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasData(
        new
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            NationalCode = "1234567890",
            FatherName = "David",
            UserName = "09123000001",
            Password = (string?)null,
            PhoneNumber = "09123000001",
            BirthDate = new DateTime(1990, 5, 14),
            Role = Role.User
        },
        new
        {
            Id = 2,
            FirstName = "Emily",
            LastName = "Johnson",
            NationalCode = "1234567891",
            FatherName = "Robert",
            UserName = "09123000002",
            Password = (string?)null,
            PhoneNumber = "09123000002",
            BirthDate = new DateTime(1988, 3, 20),
            Role = Role.User
        },
        new
        {
            Id = 3,
            FirstName = "Michael",
            LastName = "Williams",
            NationalCode = "1234567892",
            FatherName = "James",
            UserName = "09123000003",
            Password = (string?)null,
            PhoneNumber = "09123000003",
            BirthDate = new DateTime(1995, 8, 7),
            Role = Role.User
        },
        new
        {
            Id = 4,
            FirstName = "Sarah",
            LastName = "Brown",
            NationalCode = "1234567893",
            FatherName = "Thomas",
            UserName = "09123000004",
            Password = (string?)null,
            PhoneNumber = "09123000004",
            BirthDate = new DateTime(1992, 11, 2),
            Role = Role.User
        },
        new
        {
            Id = 5,
            FirstName = "David",
            LastName = "Jones",
            NationalCode = "1234567894",
            FatherName = "George",
            UserName = "09123000005",
            Password = (string?)null,
            PhoneNumber = "09123000005",
            BirthDate = new DateTime(1985, 1, 18),
            Role = Role.User
        },
        new
        {
            Id = 6,
            FirstName = "Jessica",
            LastName = "Garcia",
            NationalCode = "1234567895",
            FatherName = "Edward",
            UserName = "09123000006",
            Password = (string?)null,
            PhoneNumber = "09123000006",
            BirthDate = new DateTime(1993, 4, 25),
            Role = Role.User
        },
        new
        {
            Id = 7,
            FirstName = "Daniel",
            LastName = "Miller",
            NationalCode = "1234567896",
            FatherName = "Henry",
            UserName = "09123000007",
            Password = (string?)null,
            PhoneNumber = "09123000007",
            BirthDate = new DateTime(1989, 9, 12),
            Role = Role.User
        },
        new
        {
            Id = 8,
            FirstName = "Laura",
            LastName = "Davis",
            NationalCode = "1234567897",
            FatherName = "Charles",
            UserName = "09123000008",
            Password = (string?)null,
            PhoneNumber = "09123000008",
            BirthDate = new DateTime(1996, 12, 30),
            Role = Role.User
        },
        new
        {
            Id = 9,
            FirstName = "Admin",
            LastName = "System",
            NationalCode = "1234567898",
            FatherName = "Root",
            UserName = "admin",
            Password = "Admin@12345",
            PhoneNumber = "09123000009",
            BirthDate = new DateTime(1980, 6, 10),
            Role = Role.Admin
        },
        new
        {
            Id = 10,
            FirstName = "Kevin",
            LastName = "Wilson",
            NationalCode = "1234567899",
            FatherName = "Richard",
            UserName = "09123000010",
            Password = (string?)null,
            PhoneNumber = "09123000010",
            BirthDate = new DateTime(1991, 7, 21),
            Role = Role.User
        }
    );
    }
}
