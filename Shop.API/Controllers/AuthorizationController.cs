using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Client.AspNetCore;
using OpenIddict.Server.AspNetCore;
using Shop.API.ActionFilters;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.BLL.Interfaces;


namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthorizationController(IAuthService authService,
            ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("connect/token")]
        [GrantTypeValidationFilter(OpenIddictConstants.GrantTypes.Password)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetToken([FromForm] UserRequestAuthorizationDto userDto)
        {
            var authRequest = HttpContext.GetOpenIddictServerRequest()!;

            await _authService.AuthorizeUserAsync(userDto);

            var identity = await _tokenService.GetClaimsForToken(authRequest.Username!,
                authRequest.GetScopes());

            return SignIn(new ClaimsPrincipal(identity),
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        }

        [HttpPost("refresh/token")]
        [GrantTypeValidationFilter(OpenIddictConstants.GrantTypes.RefreshToken)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken()
        {
            var authRequest = HttpContext.GetOpenIddictServerRequest()!;
            var result = await HttpContext
                .AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                return Unauthorized(result.Failure!.Message);
            }

            var username = result.Principal.GetClaim(OpenIddictConstants.Claims.Name);
            await _authService.ValidateUsernameAsync(username);

            var identity = await _tokenService.GetClaimsForToken(username!, authRequest.GetScopes());

            return SignIn(new ClaimsPrincipal(identity),
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UserRequestRegistrationDto userDto)
        {
            await _authService.RegisterUserAsync(userDto);

            return NoContent();
        }

        [Authorize(Policy = "User")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Success");
        }
    }
}