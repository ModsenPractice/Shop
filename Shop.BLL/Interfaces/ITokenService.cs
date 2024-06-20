using System.Security.Principal;

namespace Shop.BLL.Interfaces;

public interface ITokenService{ 
    Task<string> CreateTokenAsync(string email); 
}