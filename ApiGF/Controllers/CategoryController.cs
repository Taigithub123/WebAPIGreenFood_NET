using ApiGF.Data;
using ApiGF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiGF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        public readonly DataContext _dataContext;
        public CategoryController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var get = await _dataContext.Categories.ToListAsync();
            return Ok(get);
        }
        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCatgory(Category categorys)
        {
            var cg = new Category
            {
                Name = categorys.Name,
            };
             _dataContext.Add(cg);
            await _dataContext.SaveChangesAsync();
            var get=await _dataContext.Categories.ToListAsync();
            return Ok(get);
        }
        [HttpGet("id")]
        public async Task<ActionResult<List<Category>>> GetByIdCatgory(int id)
        {
            var get = await _dataContext.Categories.FirstOrDefaultAsync(c=>c.IdCategory==id);
            return Ok(get);
        }
        [HttpPut]
        public async Task<ActionResult<List<Category>>> PutCatgory(Category categorys)
        {
            var find = await _dataContext.Categories.FindAsync(categorys.IdCategory);
            if (find == null)
            {
                return BadRequest("not found");
            }
            find.Name=categorys.Name;
            _dataContext.Update(find);
            await _dataContext.SaveChangesAsync();
            var display = await _dataContext.Categories.Where(c=>c.IdCategory == categorys.IdCategory).FirstOrDefaultAsync();
            return Ok(display);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<List<Category>>> DeleteCatgory(int id)
        {
            var findId = await _dataContext.Categories.FindAsync(id);
            if (findId == null)
            {
                return BadRequest("not found");
            }
            _dataContext.Remove(findId);
            await _dataContext.SaveChangesAsync();
            var display = await _dataContext.Categories.ToListAsync();
            return Ok(display);
        }
    }
}
