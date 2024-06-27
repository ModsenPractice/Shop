using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using Shop.BLL.Common.Configuration;
using Shop.BLL.Interfaces;
using Shop.DAL.Models;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Shop.BLL.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly ScopesOptions _scopesOptions;

        public TokenService(UserManager<User> userManager,
            IOptions<ScopesOptions> scopesOptions)
        {
            _userManager = userManager;
            _scopesOptions = scopesOptions.Value;
        }

        public async Task<ClaimsIdentity> GetClaimsForToken(string userName,
            IEnumerable<string> scopes)
        {
            //throwing UnauthorizedAccessException to hide from client
            //if username or password are incorrect
            //if user not found - incorrect username
            var user = await _userManager.FindByNameAsync(userName)
                ?? throw new UnauthorizedAccessException("Incorrect username/password pair.");

            var identity = new ClaimsIdentity(
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role
            );

            identity
                .SetClaim(Claims.Subject,
                    await _userManager.GetUserIdAsync(user))
                .SetClaim(Claims.Name,
                    await _userManager.GetUserNameAsync(user))
                .SetClaim(Claims.Email, await _userManager.GetEmailAsync(user))
                .SetClaim(Claims.Birthdate, user.BirthDay.ToString())
                .SetClaims(Claims.Role, [.. (await _userManager.GetRolesAsync(user))]);

            var correctScopes = scopes.Intersect(_scopesOptions.ValidScopes);
            identity.SetScopes(correctScopes);

            identity.SetDestinations(GetDestinations);

            return identity;
        }

        private static IEnumerable<string> GetDestinations(Claim claim)
        {
            switch (claim.Type)
            {
                case Claims.Name or Claims.PreferredUsername:
                case Claims.Role:
                case Claims.Email:
                case Claims.Birthdate:
                    yield return Destinations.AccessToken;
                    yield return Destinations.IdentityToken;
                    yield break;

                default:
                    yield return Destinations.AccessToken;
                    yield break;
            }
        }
    }
}