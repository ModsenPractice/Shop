namespace Shop.DAL.Models; 

public class Game : BaseEntity{

    public string Name {get;set;} = null!;
    public string Description {get;set;} = null!;
    public string Developer {get;set;} = null!;
    public string Publisher {get;set;} = null!;
    public decimal Price {get;set;}
    public string ImageUrl {get;set;} = null!;
    public IEnumerable<Category>? Categories {get;set;}

}
