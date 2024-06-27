namespace Shop.BLL.Exceptions.UnauthorizedExceptions
{
    public class UnauthorizedAccessException(string message) :
        Exception(message);
}