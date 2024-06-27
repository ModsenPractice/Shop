namespace Shop.BLL.Exceptions.NotFoundExceptions
{
    public class GameNotFoundException : NotFoundException
    {
        public GameNotFoundException(string message) : base(message) { }
    }
}
