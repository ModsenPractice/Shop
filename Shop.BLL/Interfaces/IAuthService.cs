using System.Security.Claims;
using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IAuthService
{
    Task RegisterUserAsync(UserRequestRegistrationDto userRequestRegistrationDto);
    Task AuthorizeUserAsync(UserRequestAuthorizationDto userRequestAuthorizationDto);
    Task ValidateUsernameAsync(string? username);
}