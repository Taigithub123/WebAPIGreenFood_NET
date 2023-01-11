using ApiGF.Data;
using ApiGF.Interface;
using ApiGF.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiGF.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Category>> AddCategory(Category category)
        {
            var cg = new Category
            {
                Name = category.Name,
            };
            _dataContext.Add(cg);
            await _dataContext.SaveChangesAsync();
            var get = await _dataContext.Categories.Select(u=>u).ToListAsync();
            return get;
        }

        public async Task<List<Category>> DeleteCategory(int id)
        {
            var findId = await _dataContext.Categories.FindAsync(id);
            if (findId == null)
            {
                throw new Exception("not found");
            }
            _dataContext.Remove(findId);
            await _dataContext.SaveChangesAsync();
            var get = await _dataContext.Categories.Select(u => u).ToListAsync();
            return get;
        }

        public Task<List<Category>> GetAllCategory()
        {
            var display = _dataContext.Categories.ToListAsync();
            return display;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var get = await _dataContext.Categories.FirstOrDefaultAsync(c => c.IdCategory == id);
            if (get == null)
            {
                throw new Exception("not found");
            }
            return get;
        }

        public async Task<List<Category>> UpdateCategory(Category category)
        {
            var FindId = await _dataContext.Categories.FindAsync(category.IdCategory);
            if (FindId == null)
            {
                throw new NotImplementedException("không tìm thấy");
            }
            FindId.Name = category.Name;
            _dataContext.Add(FindId);
            await _dataContext.SaveChangesAsync();
            var get = await _dataContext.Categories.Select(u => u).ToListAsync();
            return get;
        }
    }
}
