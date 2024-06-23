using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Common.Validators.Categories;

namespace Shop.BLL.Common.Validators.Games
{
    public class GameRequestDtoValidator<T> : AbstractValidator<T> where T : GameRequestDto
    {
        protected int minNameLength = 1;
        protected int maxNameLength = 30;
        protected int minDescriptionLength = 1;
        protected int maxDescriptionLength = 600;
        protected int minPublisherLength = 1;
        protected int maxPublisherLength = 40;
        protected int minDeveloperLength = 1;
        protected int maxDeveloperLength = 40;
        protected int maxImgUrlLength = 200;
        protected decimal minPrice = 0m;
        protected decimal maxPrice = 100000m;
        protected int pricePrecision = 9;
        protected int priceSacle = 3;

        public GameRequestDtoValidator()
        {
            RuleFor(g => g.Name).NotEmpty()
                .Length(minNameLength, maxNameLength);
            RuleFor(g => g.Description).NotEmpty()
                .Length(minNameLength, maxNameLength);
            RuleFor(g => g.Publisher).NotEmpty()
                .Length(minNameLength, maxNameLength);
            RuleFor(g => g.Developer).NotEmpty()
                .Length(minNameLength, maxNameLength);

            RuleFor(g => g.ImageUrl).NotEmpty()
                .Must(IsValidUri).WithMessage("Invalid URI.")
                .MaximumLength(maxImgUrlLength);

            RuleFor(g => g.Price).NotEmpty()
                .PrecisionScale(pricePrecision, priceSacle, false)
                .ExclusiveBetween(minPrice, maxPrice);
        }

        private static bool IsValidUri(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out _);
        }
    }
}