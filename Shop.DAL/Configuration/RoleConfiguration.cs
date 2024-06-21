using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        private readonly string[] _roles = ["User", "Admin"];
        //TODO Move roles to configuration
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            //All fields of IdentityRole configured by of identity framework

            var roles = new IdentityRole<Guid>[_roles.Length];
            for (int i = 0; i < _roles.Length; i++)
            {
                roles[i] = new IdentityRole<Guid>(_roles[i]);
            }

            builder.HasData(roles);
        }
    }
}