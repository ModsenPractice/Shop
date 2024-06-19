using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Interfaces;

public interface IUserService{
    //TODO parameters and cancelation
    public Task<IEnumerable<UserDto>> GetUsersAsync(); 
    public Task<UserDto> GetUserByIdAsync(Guid userId); 
    public Task DeleteUserAsync(Guid userId); 
    public Task UpdateUserAsync(UserForUpdateDto userForUpdateDto, Guid userId); 
}