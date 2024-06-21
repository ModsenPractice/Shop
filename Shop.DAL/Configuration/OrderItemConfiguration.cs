using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Models;

namespace Shop.DAL.Configuration
{
    public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        //TODO create triggers for createdAt and modifiedAt
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.Property(oi => oi.Count)
                .IsRequired();
        }
    }
}