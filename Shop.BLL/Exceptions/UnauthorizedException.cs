namespace Shop.BLL.Exceptions
{
    public class UnauthorizedException(string message) :
        Exception(message);
}