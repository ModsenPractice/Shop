using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Models;

namespace Shop.DAL.Configuration
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        //Total numbers
        private const int PRICE_PRECISION = 20;
        //Total numbers after the dot
        private const int PRICE_SCALE = 3;

        //TODO create triggers for createdAt and modifiedAt; Move const to configuration
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            //Order - OrderItem | One to Many
            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasPrecision(PRICE_PRECISION, PRICE_SCALE);
        }
    }
}