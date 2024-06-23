using FluentValidation;
using Shop.BLL.Common.DataTransferObjects.Games;
using Shop.BLL.Common.Validators.Categories;

namespace Shop.BLL.Common.Validators.Games
{
    public class GameCreationDtoValidator : GameRequestDtoValidator<GameRequestCreationDto>;
}