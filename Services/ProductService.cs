using CustomBasePattern.Entities;
using CustomBasePattern.Interfaces;

namespace CustomBasePattern.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();
        public ProductService()
        {
            // Seed sample data
            for (int i = 1; i <= 50; i++)
            {
                _products.Add(new Product { Id = i, Name = $"Product {i}", Price = 10 * i, Category = "General" });
            }
        }

        public IEnumerable<Product> GetPaginatedProducts(int pageNumber, int pageSize, out int totalCount)
        {
            totalCount = _products.Count;
            return _products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }
    }
}
