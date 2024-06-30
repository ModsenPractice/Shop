namespace Shop.BLL.Common.DataTransferObjects.Users
{
   public record UserRequestAuthorizationDto
   {
      public string Username { get; set; } = null!;
      public string Password { get; set; } = null!;
   }
}