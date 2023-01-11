using ApiGF.Model;

namespace ApiGF.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task<List<Category>> AddCategory(Category category);
        Task<List<Category>> UpdateCategory(Category category);
        Task<List<Category>> DeleteCategory(int id);

    }
}
