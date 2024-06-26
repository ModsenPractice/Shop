using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Common.Validators.Users
{
    public class UserAuthorizationDtoValidator : AbstractValidator<UserRequestAuthorizationDto>
    {
        protected const int MIN_PASSWORD_LENGTH = 10;
        protected const int MAX_PASSWORD_LENGTH = 30;
        protected const int MAX_EMAIL_LENGTH = 30;
        public UserAuthorizationDtoValidator()
        {
            RuleFor(u => u.Email).NotEmpty()
                .MaximumLength(MAX_EMAIL_LENGTH)
                .EmailAddress();

            RuleFor(u => u.Password).NotEmpty()
                .Length(MIN_PASSWORD_LENGTH, MAX_PASSWORD_LENGTH);
        }
    }
}