
using eTicaret.Core.DbModels;
using eTicaret.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTicaret.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _context.Products.ToListAsync();
            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
    }
}
