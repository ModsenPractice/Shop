using Shop.BLL.Common.DataTransferObjects.Categories;
using Shop.BLL.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Shop.BLL.Common.DataTransferObjects.Users;
using Shop.DAL.Repositories;
using System.Linq.Expressions;
using Shop.DAL.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Shop.BLL.Exceptions.NotFoundExceptions;
using Shop.BLL.Common.DataTransferObjects.Games;

namespace Shop.BLL.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork; 
        private readonly ILogger<CategoryService> _logger; 

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<CategoryService> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.GetRange(c => true, cancellationToken);

            var categoriesDto = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
            
            return categoriesDto;
        }

        public async Task<CategoryResponseDto> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetSingle(c => c.Id.Equals(id) ,cancellationToken);

            if(category is null)
            {
                _logger.LogError("Category not found exception in method GetCategoryByIdAsync in CategoryService");
                throw new NotFoundException($"Category with id: {id} not found.");
            }

            var categoryDto = _mapper.Map<CategoryResponseDto>(category);

            return categoryDto;
        }

        public async Task CreateCategoryAsync(Guid id, CategoryRequestCreationDto categoryRequestCreationDto, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetSingle(c => c.Id.Equals(id), cancellationToken);

            if (category is null)
            {
                category = _mapper.Map<Category>(categoryRequestCreationDto);
                _unitOfWork.CategoryRepository.Create(category);
                await _unitOfWork.SaveChangesAsync();
            }

            _logger.LogError("Category not found exception in method CreateUserAsync in CategoryService");
            throw new NotFoundException($"Category with id: {id} not found.");
        }

        public async Task UpdateCategoryAsync(Guid id, CategoryRequestUpdateDto categoryRequestUpdateDto, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetSingle(c => c.Id.Equals(id), cancellationToken);

            if (category is null)
            {
                _logger.LogError("Category not found exception in method UpdateUserAsync in CategoryService");
                throw new NotFoundException($"Category with id: {id} not found.");
            }

            _mapper.Map(categoryRequestUpdateDto, category);
            _unitOfWork.CategoryRepository.Update(category);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetSingle(c => c.Id.Equals(id), cancellationToken);

            if(category is null)
            {
                _logger.LogError("Category not found exception in method DeleteUserAsync in CategoryService");
                throw new NotFoundException($"Category with id: {id} not found.");
            }

            _unitOfWork.CategoryRepository.Delete(category);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
