namespace Shop.DAL.Models;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public IEnumerable<OrderItem>? OrderItems { get; set; }
    public decimal TotalPrice { get; set; }
}