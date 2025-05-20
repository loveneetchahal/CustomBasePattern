using CustomBasePattern.Entities;

namespace CustomBasePattern.Interfaces
{
    public interface IProductService
    {  
        IEnumerable<Product> GetPaginatedProducts(int pageNumber, int pageSize, out int totalCount);
        Product GetProductById(int id);
        void AddProduct(Product product);
    }
}
