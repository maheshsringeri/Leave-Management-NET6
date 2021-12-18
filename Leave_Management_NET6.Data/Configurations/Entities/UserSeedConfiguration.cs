using Leave_Management_NET6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leave_Management_NET6.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Firstname = "System",
                    Lastname = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "44694538-33ff-4f55-93c5-f8bf732d7a07",
                    Email = "user1@localhost.com",
                    NormalizedEmail = "USER1@LOCALHOST.COM",
                    UserName = "user1@localhost.com",
                    NormalizedUserName = "USER1@LOCALHOST.COM",
                    Firstname = "System",
                    Lastname = "User1",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    EmailConfirmed = true
                }
            ); ;
        }
    }
}