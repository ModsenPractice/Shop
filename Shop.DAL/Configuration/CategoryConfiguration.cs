using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.DAL.Models;

namespace Shop.DAL.Configuration
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        //TODO create triggers for createdAt and modifiedAt; Move const to configuration
        private const int CATEGORY_NAME_MAX_LENGTH = 30;
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(CATEGORY_NAME_MAX_LENGTH);
        }
    }
}