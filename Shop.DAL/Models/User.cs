using Microsoft.AspNetCore.Identity;

namespace Shop.DAL.Models; 

public class User: IdentityUser<Guid>{
    public string FirstName {get;set;} = null!;
    public string LastName {get;set;} = null!;
    public DateOnly BirthDay {get;set;} 
    public IEnumerable<Order>? Orders {get;set;}
}