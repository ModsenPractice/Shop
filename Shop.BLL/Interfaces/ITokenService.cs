using Shop.DAL.Models;

namespace Shop.BLL.Interfaces;

public interface ITokenService{ 
    Task<string> CreateTokenAsync(User user); 
}