namespace Shop.BLL.Common.DataTransferObjects.Users
{
   public record UserForAuthorizationDto
   {
      public string Email { get; set; } = null!;
      public string Password { get; set; } = null!;
   }
}