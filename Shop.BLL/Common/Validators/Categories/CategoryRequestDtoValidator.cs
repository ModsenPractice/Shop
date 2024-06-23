using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.Validators.Categories
{
    public abstract class CategoryRequestDtoValidator<T> : AbstractValidator<T> where T :
        CategoryRequestDto
    {
        protected const int MIN_NAME_LENGTH = 2;
        protected const int MAX_NAME_LENGTH = 30;
        public CategoryRequestDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .Length(MIN_NAME_LENGTH, MAX_NAME_LENGTH);
        }
    }
}