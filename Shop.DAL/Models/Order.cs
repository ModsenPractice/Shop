namespace Shop.DAL.Models; 

public class Order : BaseEntity{
    public Guid UserId {get;set;} 
    public User User {get;set;}
    public IEnumerable<OrderItem> OrderItems {get;set;}
    public decimal TotalPrice {get;set;}
}