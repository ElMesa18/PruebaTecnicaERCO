namespace ProductsApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}

// Models/ProductDto.cs
public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}