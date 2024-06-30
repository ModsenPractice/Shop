using System.Security.Claims;

namespace Shop.BLL.Interfaces;

public interface ITokenService
{
    /// <summary>
    /// Creates and populates claimsIdentity for token issuing 
    /// with claims and set their destinations
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="scopes"></param>
    /// <returns></returns>
    Task<ClaimsIdentity> GetClaimsForToken(string userName, IEnumerable<string> scopes);
}