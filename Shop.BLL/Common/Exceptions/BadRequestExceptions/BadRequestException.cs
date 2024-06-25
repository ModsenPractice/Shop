namespace Shop.BLL.Common.Exceptions.BadRequestExceptions
{
    public abstract class BadRequestException(string message) : Exception(message);
}