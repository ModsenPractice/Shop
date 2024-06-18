namespace Shop.DAL.Models; 

public class Game : BaseEntity{

    public string Name {get;set;}
    public string Description {get;set;}
    public string Developer {get;set;}
    public string Publisher {get;set;}
    public decimal Price {get;set;}
    public string ImageUrl {get;set;}
    public IEnumerable<Category> Categories {get;set;}

}
