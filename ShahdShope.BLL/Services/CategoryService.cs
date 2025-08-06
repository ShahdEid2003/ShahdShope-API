using Mapster;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return categoryRepository.Add(category);
            
        }

        public int DeleteCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null)
            {
                return 0;

            }
            return categoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponses> GetAllCategories()
        {
            var categories = categoryRepository.GetAll();
            return categories.Adapt<IEnumerable<CategoryResponses>>();
        }

        public CategoryResponses? GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponses>();
        }

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = categoryRepository.GetById(id);
            if (category is null)
            {
                return 0;
            }
            category.Name = request.Name;
            return categoryRepository.Update(category);
        }
        public bool ToggleStatus(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category is null)
            {
                return false;
            }
            category.Status = category.Status == Status.Active ? Status.Inactive : Status.Active;
            categoryRepository.Update(category);
            return true;
        }
    }
}
