using ApiGF.Data;
using ApiGF.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {
            var get = await _dataContext.Products.Include(u=>u.Categories).ToListAsync();
            return Ok(get);
        }
        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var find = await _dataContext.Categories.Where(u => u.IdCategory == product.IdCategory).FirstOrDefaultAsync();
            if(find == null)
            {
                return NotFound();
            }
            var products = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Status = product.Status,
                Price = product.Price,
                IdCategory = product.IdCategory,
                Categories = find
            };
            _dataContext.Add(products);
            await _dataContext.SaveChangesAsync();
            var display = await _dataContext.Products.Include(id => id.Categories).ToListAsync();
            return Ok(display);
        }
        [HttpGet("id")]
        public async Task<ActionResult<List<Product>>> GetByIDProduct(int id)
        {
            var get = await _dataContext.Products.Where(u=>u.Id==id).FirstOrDefaultAsync();
            if (get==null)
            {
                return BadRequest("not found");
            }
            var display = await _dataContext.Products.Include(id => id.Categories).ToListAsync();
            return Ok(display);
        }
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var get = await _dataContext.Products.FindAsync(product.Id);
            if (get == null)
            {
                return BadRequest("not found");
            }
            var find = await _dataContext.Categories.Where(u => u.IdCategory == product.IdCategory).FirstOrDefaultAsync();
            if (find == null)
            {
                return NotFound();
            }
            get.Name = product.Name;
            get.Description = product.Description;
            get.Status = product.Status;
            get.Price = product.Price;
            get.IdCategory = product.IdCategory;
            get.Categories = find;
            _dataContext.Update(get);
            await _dataContext.SaveChangesAsync();
            var display = await _dataContext.Products.Include(id=>id.Categories).ToListAsync();
            return Ok(display);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var get = await _dataContext.Products.FindAsync(id);
            if (get == null)
            {
                return BadRequest("not found");
            }
            _dataContext.Remove(get);
            await _dataContext.SaveChangesAsync();
            var display = await _dataContext.Products.Include(id => id.Categories).ToListAsync();
            return Ok(display);
        }
    }
}
