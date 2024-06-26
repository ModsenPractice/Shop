using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Users;

namespace Shop.BLL.Common.Validators.Users
{
    public abstract class UserRequestDtoValidator<T> :
        AbstractValidator<T> where T : UserRequestDto
    {
        protected const int MIN_USERNAME_LENGTH = 4;
        protected const int MAX_USERNAME_LENGTH = 30;
        protected const int MIN_PASSWORD_LENGTH = 10;
        protected const int MAX_PASSWORD_LENGTH = 30;
        protected const int MAX_EMAIL_LENGTH = 30;
        protected const int MIN_NAME_LENGTH = 1;
        protected const int MAX_NAME_LENGTH = 40;
        protected const string NAME_REGEX = @"(?i)^[a-z ,.'-]+$";
        protected readonly DateOnly MIN_BIRTHDAY = DateOnly.Parse("01-01-1900");
        public UserRequestDtoValidator()
        {
            RuleFor(u => u.UserName).NotEmpty()
                .Length(MIN_USERNAME_LENGTH, MAX_USERNAME_LENGTH);
            RuleFor(u => u.Password).NotEmpty()
                .Length(MIN_PASSWORD_LENGTH, MAX_PASSWORD_LENGTH);

            RuleFor(u => u.FirstName).NotEmpty()
                .Length(MIN_NAME_LENGTH, MAX_NAME_LENGTH)
                .Matches(NAME_REGEX);
            RuleFor(u => u.LastName).NotEmpty()
                .Length(MIN_NAME_LENGTH, MAX_NAME_LENGTH)
                .Matches(NAME_REGEX);

            RuleFor(u => u.Email).NotEmpty()
                .MaximumLength(MAX_EMAIL_LENGTH)
                .EmailAddress();

            RuleFor(u => u.BirthDay)
                .GreaterThanOrEqualTo(MIN_BIRTHDAY);

            RuleFor(u => u.Roles).NotEmpty();
            RuleForEach(u => u.Roles).NotEmpty();
        }
    }
}