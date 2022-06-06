using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fc756a21-0731-4ebf-9e4f-a495d819410b",
                    UserId = "30893af3-12ce-4a50-8dac-7bde58106aaf"
                },

                new IdentityUserRole<string>
                {
                    RoleId = "8f64a5f6-2e77-41ab-a790-a73e6898a34b",
                    UserId = "048880ff-3248-48e9-8400-c27c814ee2c1"
                }
                );
        }
    }
}
