using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IAuthService{ 
    Task RegisterUserAsync(UserRequestRegistrationDto userRequestRegistrationDto); 
    Task<bool> AuthorizeUserAsync(UserRequestAuthorizationDto userRequestAuthorizationDto);
}