using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.BLL.Exceptions.InternalExceptions;
using Shop.BLL.Exceptions.NotFoundExceptions;
using Shop.BLL.Interfaces;
using Shop.DAL.Models;

namespace Shop.BLL.Services; 

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager; 
    private readonly IMapper _mapper; 
    private readonly ILogger<UserService> _logger; 

    public UserService(IMapper mapper, ILogger<UserService> logger, UserManager<User> userManager)
    {
        _userManager = userManager; 
        _logger = logger; 
        _mapper = mapper; 
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString()); 

        if(user is not null)
        { 
            await _userManager.DeleteAsync(user); 
        }
    } 

    public async Task<UserResponseDto> GetUserByIdAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if(user is not null)
        {
            var userDto = _mapper.Map<UserResponseDto>(user); 
            return userDto;
        }
        else
        {
            _logger.LogError("User not found exception in method GetUserByIdAsync in UserService");
            throw new UserNotFoundException(id);
        } 
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync(); 
        var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users); 
        return userDtos; 
    }

    public async Task UpdateUserAsync(Guid id, UserRequestUpdateDto userRequestUpdateDto)
    {
        var user = await _userManager.FindByIdAsync(id.ToString())
            ?? throw new UserNotFoundException(id); 
        _mapper.Map(userRequestUpdateDto, user); 
        var result = await _userManager.UpdateAsync(user);
        if(!result.Succeeded){
            _logger.LogError("Internal exception in method UpdateUserAsync in UserService");
            throw new InternalException();   
        } 
    }
}