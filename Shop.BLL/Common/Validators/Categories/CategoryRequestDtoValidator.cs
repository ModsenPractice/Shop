using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.BLL.Common.Validators.Categories
{
    public class CategoryRequestDtoValidator<T> : AbstractValidator<T> where T :
        CategoryRequestDto
    {
        protected int minNameLength = 2;
        protected int maxNameLength = 30;
        public CategoryRequestDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty()
                .Length(minNameLength, maxNameLength);
        }
    }
}