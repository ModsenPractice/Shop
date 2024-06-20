namespace Shop.BLL.Common.DataTransferObjects.Users
{
   public record UserResponseDto
   {
      public Guid Id { get; set; }
      public string UserName { get; set; } = null!;
      public string Email { get; set; } = null!;
      public string FirstName { get; set; } = null!;
      public string LastName { get; set; } = null!;
      public DateOnly BirthDay { get; set; }
      public IEnumerable<string> Roles { get; set; } = null!;
   }
}