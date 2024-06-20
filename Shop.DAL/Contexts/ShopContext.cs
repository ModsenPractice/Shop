using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;

namespace Shop.DAL.Contexts
{
   public class ShopContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
   {
      public DbSet<Game> Games { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<OrderItem> OrderItems { get; set; }

      public ShopContext(DbContextOptions<ShopContext> options)
         : base(options)
      {
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
      }

   }
}