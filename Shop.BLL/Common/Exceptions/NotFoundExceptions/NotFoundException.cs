namespace Shop.BLL.Common.Exceptions.NotFoundExceptions
{
    public abstract class NotFoundException(string message) : Exception(message);
}