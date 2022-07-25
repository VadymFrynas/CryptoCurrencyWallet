using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoCurrency.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "RegistredUser",
                NormalizedName = "REGISTREDUSER"
            },
            new IdentityRole
            {
                Name = "Visitors",
                NormalizedName = "VISITORS"
            });
        }
    }
}
