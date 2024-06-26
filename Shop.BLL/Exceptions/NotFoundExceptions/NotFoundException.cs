namespace Shop.BLL.Exceptions.NotFoundExceptions
{
    public abstract class NotFoundException(string message) : Exception(message);
}