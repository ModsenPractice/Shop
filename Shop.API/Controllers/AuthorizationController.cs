using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Client.AspNetCore;
using OpenIddict.Server.AspNetCore;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetToken()
        {
            var authRequest = HttpContext.GetOpenIddictClientRequest()!;

            if (authRequest.IsPasswordGrantType())
            {
                await HandlePasswordGrant(new UserRequestAuthorizationDto()
                {
                    Email = authRequest.Username!,
                    Password = authRequest.Password!
                }, authRequest);
            }

            return BadRequest("The authorization grant type is not supported by the authorization server.");
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(UserRequestRegistrationDto userDto)
        {
            await _authService.RegisterUserAsync(userDto);

            return NoContent();
        }


        private async Task<IActionResult> HandlePasswordGrant(UserRequestAuthorizationDto userDto,
            OpenIddictRequest authRequest)
        {
            await _authService.AuthorizeUserAsync(userDto);

            var identity = await _tokenService.GetClaimsForToken(authRequest.Username!,
                authRequest.GetScopes());

            return SignIn(new ClaimsPrincipal(identity),
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
    }
}