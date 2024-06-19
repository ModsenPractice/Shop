using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IAuthService{ 
    //TODO parameters and cancelation
    public Task<string>  AuthorizeUserAsync(); 
    public Task RegisterUserAsync(UserForRegistrationDto userForRegistrationDto); 
    Task<bool> ValidateUser(UserForAuthorizationDto userForAuth);
    Task<string> CreateToken(); 
}