using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Common.Validators.Categories;

namespace Shop.BLL.Common.Validators.Games
{
    public class GameRequestDtoValidator<T> : AbstractValidator<T> where T : GameRequestDto
    {
        protected const int MIN_NAME_LENGTH = 1;
        protected const int MAX_NAME_LENGTH = 30;
        protected const int MIN_DESCRIPTION_LENGTH = 1;
        protected const int MAX_DESCRIPTION_LENGTH = 600;
        protected const int MIN_PUBLISHER_LENGTH = 1;
        protected const int MAX_PUBLISHER_LENGTH = 40;
        protected const int MIN_DEVELOPER_LENGTH = 1;
        protected const int MAX_DEVELOPER_LENGTH = 40;
        protected const decimal MIN_PRICE = 0m;
        protected const decimal MAX_PRICE = 10000m;
        protected const int PRICE_PRECISION = 7;
        protected const int PRICE_SCALE = 3;
        protected const int MIN_CATEGORY_LENGTH = 2;
        protected const int MAX_CATEGORY_LENGTH = 30;

        public GameRequestDtoValidator()
        {
            RuleFor(g => g.Name).NotEmpty()
                .Length(MIN_NAME_LENGTH, MAX_NAME_LENGTH);
            RuleFor(g => g.Description).NotEmpty()
                .Length(MIN_DESCRIPTION_LENGTH, MAX_DESCRIPTION_LENGTH);
            RuleFor(g => g.Publisher).NotEmpty()
                .Length(MIN_PUBLISHER_LENGTH, MAX_PUBLISHER_LENGTH);
            RuleFor(g => g.Developer).NotEmpty()
                .Length(MIN_DEVELOPER_LENGTH, MAX_DEVELOPER_LENGTH);

            //TODO create class for image (name, extension, file)
            RuleFor(g => g.Image).NotEmpty();

            RuleFor(g => g.Price).NotEmpty()
                .PrecisionScale(PRICE_PRECISION, PRICE_SCALE, false)
                .ExclusiveBetween(MIN_PRICE, MAX_PRICE);

            RuleFor(g => g.Categories).NotEmpty();

            RuleForEach(g => g.Categories).NotEmpty()
                .Length(MIN_CATEGORY_LENGTH, MAX_CATEGORY_LENGTH);
        }
    }
}