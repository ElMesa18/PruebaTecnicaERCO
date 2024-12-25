using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository = new();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var newProduct = _repository.Add(product);
            return Ok(new { message = "Product created successfully", id = newProduct.Id });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result)
            {
                return Ok(new { message = $"Product {id} deleted successfully" });
            }
            return NotFound(new { message = $"Product {id} not found" });
        }
    }
}