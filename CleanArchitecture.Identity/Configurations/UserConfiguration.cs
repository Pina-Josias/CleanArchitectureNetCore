using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "30893af3-12ce-4a50-8dac-7bde58106aaf",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Josias",
                    Apellidos = "Pina",
                    UserName = "KrauserX",
                    NormalizedUserName = "krauserx",
                    PasswordHash = hasher.HashPassword(null, "josias4528"),
                    EmailConfirmed = true,

                },
                new ApplicationUser
                {
                    Id = "048880ff-3248-48e9-8400-c27c814ee2c1",
                    Email = "josias@localhost.com",
                    NormalizedEmail = "josias@localhost.com",
                    Nombre = "Jhon",
                    Apellidos = "Perez",
                    UserName = "JPerex",
                    NormalizedUserName = "jperex",
                    PasswordHash = hasher.HashPassword(null, "josias4528"),
                    EmailConfirmed = true,

                }
           );
        }
    }
}
