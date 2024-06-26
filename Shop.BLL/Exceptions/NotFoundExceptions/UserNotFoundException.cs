namespace Shop.BLL.Exceptions.NotFoundExceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid id) : base($"User with id: {id} not found.")
    {
    }
}