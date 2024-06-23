using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Common.Validators.Categories;

namespace Shop.BLL.Common.Validators.Games
{
    public class GameCreationDtoValidator : GameRequestDtoValidator<GameRequestCreationDto>
    {
        public GameCreationDtoValidator()
        {
            RuleFor(g => g.Categories).NotEmpty();
            RuleForEach(g => g.Categories)
                .SetValidator(new CategoryCreationDtoValidator());
        }
    }
}