using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           return await context.Products.ToListAsync();
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
          var product =  await context.Products.FindAsync(id);

          if(product == null) return NotFound();

          return product;
        } 
    }
}