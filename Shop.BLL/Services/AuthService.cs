using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.BLL.Exceptions.InternalExceptions;
using Shop.BLL.Interfaces;
using Shop.DAL.Models;

namespace Shop.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IMapper mapper, UserManager<User> userManager,
            ILogger<AuthService> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<bool> AuthorizeUserAsync(UserRequestAuthorizationDto userRequestAuthorizationDto)
        {
            var user = await _userManager
                .FindByEmailAsync(userRequestAuthorizationDto.Email);

            var res = user != null && await _userManager.CheckPasswordAsync(user,
                userRequestAuthorizationDto.Password);

            if (!res)
            {
                return false;
            }

            return true;
        }

        public async Task RegisterUserAsync(
            UserRequestRegistrationDto userRequestRegistrationDto)
        {
            var user = _mapper.Map<User>(userRequestRegistrationDto);

            var res = await _userManager
                .CreateAsync(user, userRequestRegistrationDto.Password);

            if (res.Succeeded)
            {
                await _userManager
                    .AddToRolesAsync(user, userRequestRegistrationDto.Roles);
            }
            else
            {
                var errors = new StringBuilder();
                foreach (var error in res.Errors)
                {
                    errors.Append($"{error.Code}:{error.Description}\n");
                }

                _logger.LogError("Error occured while creating user: {error}",
                    errors);

                throw new InternalException();
            }
        }
    }
}