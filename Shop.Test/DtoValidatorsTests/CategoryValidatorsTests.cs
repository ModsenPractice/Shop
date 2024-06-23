using Shop.BLL.Common.Validators.Categories;
using FluentValidation.TestHelper;
using Shop.BLL.Common.DataTransferObjects.Categories;

namespace Shop.Test.DtoValidatorsTests
{
    public class CategoryValidatorsTests
    {
        private readonly CategoryCreationDtoValidator _creationValidator = new();
        private readonly CategoryUpdateDtoValidator _updateValidator = new();


        #region Creation dto validation

        [Theory]
        [InlineData("shooter")]
        [InlineData("Rogue-lite")]
        [InlineData("FPS")]
        [InlineData("123456789012345678901234567890")]
        [InlineData("3D")]
        public void ValidNameCategoryCreation_ShouldNotHaveValidationError(string name)
        {
            var result = _creationValidator.TestValidate(
                new CategoryRequestCreationDto()
                {
                    Name = name
                }
            );

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyNameCategoryCreation_ShouldHaveValidationError(string name)
        {
            var result = _creationValidator.TestValidate(
                new CategoryRequestCreationDto()
                {
                    Name = name
                }
            );
            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("1234567890123456789012345678901")]
        public void InvalidNameLengthCategoryCreation_ShouldHaveValidationError(string name)
        {
            var result = _creationValidator.TestValidate(
                new CategoryRequestCreationDto()
                {
                    Name = name
                }
            );

            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        #endregion

        #region Update dto validation

        [Theory]
        [InlineData("shooter")]
        [InlineData("Rogue-lite")]
        [InlineData("FPS")]
        [InlineData("123456789012345678901234567890")]
        [InlineData("3D")]
        public void ValidNameCategoryUpdate_ShouldNotHaveValidationError(string name)
        {
            var result = _updateValidator.TestValidate(
                new CategoryRequestUpdateDto()
                {
                    Name = name
                }
            );

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EmptyNameCategoryUpdate_ShouldHaveValidationError(string name)
        {
            var result = _updateValidator.TestValidate(
                new CategoryRequestUpdateDto()
                {
                    Name = name
                }
            );

            result.ShouldHaveValidationErrorFor(c => c.Name);
        }


        [Theory]
        [InlineData("a")]
        [InlineData("1234567890123456789012345678901")]
        public void InvalidNameLengthCategoryUpdate_ShouldHaveValidationError(string name)
        {
            var result = _updateValidator.TestValidate(
                new CategoryRequestUpdateDto()
                {
                    Name = name
                }
            );

            result.ShouldHaveValidationErrorFor(c => c.Name);
        }

        #endregion

    }
}