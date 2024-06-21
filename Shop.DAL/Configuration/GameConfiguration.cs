using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Models;

namespace Shop.DAL.Configuration
{
    public class GameConfiguration : BaseEntityConfiguration<Game>
    {
        private const int GAME_NAME_MAX_LENGTH = 30;
        private const int DESCRIPTION_MAX_LENGTH = 600;
        private const int PUBLISHER_MAX_LENGTH = 40;
        private const int DEVELOPER_MAX_LENGTH = 40;
        private const int IMG_URL_MAX_LENGTH = 200;

        //Total numbers
        private const int PRICE_PRECISION = 20;
        //Total numbers after the dot
        private const int PRICE_SCALE = 3;

        public override void Configure(EntityTypeBuilder<Game> builder)
        {
            base.Configure(builder);

            //Game - Category | Many to Many
            builder.HasMany(g => g.Categories)
                .WithMany(c => c.Games);

            //Game - OrderItem | One to Many
            builder.HasMany(g => g.OrderItems)
                .WithOne(oi => oi.Game)
                .HasForeignKey(oi => oi.GameId)
                .IsRequired();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(GAME_NAME_MAX_LENGTH);

            builder.Property(g => g.Description)
                .IsRequired()
                .HasMaxLength(DESCRIPTION_MAX_LENGTH);

            builder.Property(g => g.Developer)
                .IsRequired()
                .HasMaxLength(DEVELOPER_MAX_LENGTH);

            builder.Property(g => g.Publisher)
                .IsRequired()
                .HasMaxLength(PUBLISHER_MAX_LENGTH);

            builder.Property(g => g.ImageUrl)
                .IsRequired()
                .HasMaxLength(IMG_URL_MAX_LENGTH);

            builder.Property(g => g.Price)
                .IsRequired()
                .HasPrecision(PRICE_PRECISION, PRICE_SCALE);

        }
    }
}