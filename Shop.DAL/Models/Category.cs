namespace Shop.DAL.Models; 

public class Category : BaseEntity{ 
    public string Name {get;set;}
    public IEnumerable<Game> Games {get;set;}
}