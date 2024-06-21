namespace Shop.DAL.Models;

public class OrderItem : BaseEntity
{
    public Guid GameId { get; set; }
    public Game? Game { get; set; }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public int Count { get; set; }
}