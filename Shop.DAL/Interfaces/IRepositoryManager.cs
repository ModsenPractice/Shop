namespace Shop.DAL.Interfaces; 

public interface IRepositoryManager{
    public IGameRepository gameRepository {get;}
    public ICategoryRepository categoryRepository {get;}

    public Task SaveChangesAsync(); 
}