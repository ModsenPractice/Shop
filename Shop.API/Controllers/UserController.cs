using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.BLL.Interfaces;

namespace Shop.API.Controllers; 


[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await userService.GetUsersAsync();
        return Ok(users); 
    }

    [HttpGet("{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetUserByIdAsync(Guid id)
    {
        var user = await userService.GetUserByIdAsync(id);
        return Ok(user);  
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> UpdateUserAsync(Guid id,[FromBody] UserRequestUpdateDto userRequestDto)
    {
        await userService.UpdateUserAsync(id, userRequestDto);
        return NoContent(); 
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        await userService.DeleteUserAsync(id);
        return NoContent(); 
    }
}