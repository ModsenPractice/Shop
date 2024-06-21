using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IUserService{
    Task<IEnumerable<UserResponseDto>> GetUsersAsync(); 
    Task<UserResponseDto> GetUserByIdAsync(Guid id); 
    Task DeleteUserAsync(Guid id); 
    Task UpdateUserAsync(Guid id, UserRequestUpdateDto userRequestUpdateDto); 
}