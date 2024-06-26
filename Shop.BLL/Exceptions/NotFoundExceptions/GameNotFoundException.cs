namespace Shop.BLL.Exceptions.NotFoundExceptions
{
    public class GameNotFoundException : NotFoundException
    {
        public GameNotFoundException(Guid id) : base($"Game with id: {id} not found.") 
        {
        }
    }
}
