using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IAuthService{ 
    Task RegisterUserAsync(UserRequestRegistrationDto dto); 
    Task<bool> AuthorizeUserAsync(UserRequestAuthorizationDto dto);
}