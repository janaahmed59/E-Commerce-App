using E_Commerce_App.DTOs.CategoryDTO;
namespace E_Commerce_App.Services.Interface
{
    public interface ICategoryService
    {

        public IEnumerable<GetCategoriesDTO> GetAllCategories();
        public void CreateCategory(CreateCategoryDTO dto); // admin
        public void UpdateCategory(int id, UpdateCategoryDTO dto);
        public void DeleteCategory(int id);
        //CategoryService
        // |
        // |-- GetCategories
        // |-- CreateCategory
        // |-- UpdateCategory
        // |-- DeleteCategory

    }

}