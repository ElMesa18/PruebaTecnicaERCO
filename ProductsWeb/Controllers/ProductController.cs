using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using ProductsWeb.Models;

namespace ProductsWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("ProductsApi");
            var products = await client.GetFromJsonAsync<List<Product>>("products");
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var client = _clientFactory.CreateClient("ProductsApi");
                var response = await client.PostAsync("products", content);
                
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            var client = _clientFactory.CreateClient("ProductsApi");
            var response = await client.DeleteAsync("products");
            
            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Productos eliminados correctamente";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}