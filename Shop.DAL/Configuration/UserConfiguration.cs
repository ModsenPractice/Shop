using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Models;

namespace Shop.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const int FIRST_NAME_MAX_LENGTH = 50;
        private const int LAST_NAME_MAX_LENGTH = 50;
        //TODO Move const to configuration
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //All fields of IdentityUser configured by of identity framework

            //User - Order| One to Many
            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(FIRST_NAME_MAX_LENGTH);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(LAST_NAME_MAX_LENGTH);

        }
    }
}