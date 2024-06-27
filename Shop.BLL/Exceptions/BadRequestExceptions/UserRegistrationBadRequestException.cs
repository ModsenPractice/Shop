namespace Shop.BLL.Exceptions.BadRequestExceptions
{
    public class UserRegistrationBadRequestException(string message) :
        BadRequestException(message);
}