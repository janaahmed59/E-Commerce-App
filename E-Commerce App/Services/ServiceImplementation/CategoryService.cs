using E_Commerce_App.DTOs.CategoryDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;

namespace E_Commerce_App.Services.ServiceImplementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unit;
        public CategoryService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IEnumerable<GetCategoriesDTO> GetAllCategories()
        {
            var repo = _unit.Repository<Category>();
            var list = repo.GetAll().Select(g => new GetCategoriesDTO
            {
                CategoryName = g.Name
            });
            return list;
        }
        
        public void CreateCategory(CreateCategoryDTO dto)
        {
            var repo = _unit.Repository<Category>();
            var category = new Category
            {
                Name = dto.CategoryName
            };
            repo.Create(category);
            _unit.Save();

        }// admin
        public void UpdateCategory(int id,UpdateCategoryDTO dto)
        {
            var repo = _unit.Repository<Category>();
            var category = repo.GetById(id);
            if (category != null)
            {
                category.Name = dto.CategoryName;
                repo.Update(category);
                _unit.Save();
            }
        }
        public void DeleteCategory(int id)
        {
            var repo = _unit.Repository<Category>();
            var category = repo.GetById(id);
            if (category != null)
            {
                repo.Delete(category);
                _unit.Save();
            }
        }
    }
}
