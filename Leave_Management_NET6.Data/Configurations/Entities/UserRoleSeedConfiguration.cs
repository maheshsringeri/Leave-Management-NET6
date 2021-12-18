using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leave_Management_NET6.Data
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "vv694538-33ff-7755-93c5-f8b7799d7a07",
                    UserId = "3b694538-33ff-4f55-93c5-f8bf732d7a07"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                    UserId = "44694538-33ff-4f55-93c5-f8bf732d7a07"
                }
            );

        }
    }
}