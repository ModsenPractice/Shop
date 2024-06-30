using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Common.DataTransferObjects.Categories;
using Shop.BLL.Interfaces;

namespace Shop.API.Controllers
{
    [Route("api/catrgory")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categories;

        public CategoryController(ICategoryService categories)
        {
            _categories = categories;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categories.GetCategoriesAsync(cancellationToken);

            return Ok(categories);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetCategoryById(Guid id,
            CancellationToken cancellationToken)
        {
            var category = await _categories.GetCategoryByIdAsync(id, cancellationToken);

            return Ok(category);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateCategory(Guid id, CategoryRequestUpdateDto categoryDto,
            CancellationToken cancellationToken)
        {
            await _categories.UpdateCategoryAsync(id, categoryDto, cancellationToken);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateCategory(CategoryRequestCreationDto categoryDto,
            CancellationToken cancellationToken)
        {
            var createdCategory =
                await _categories.CreateCategoryAsync(categoryDto, cancellationToken);

            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id },
                createdCategory);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCategory(Guid id,
            CancellationToken cancellationToken)
        {
            await _categories.DeleteCategoryAsync(id, cancellationToken);

            return NoContent();
        }
    }
}