using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository
    {
        private static readonly List<Product> _products = [];
        private static int _currentId = 1;

        public Product Add(Product product)
        {
            product.Id = _currentId++;
            _products.Add(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return _products.Remove(product);
            }
            return false;
        }
    }
}