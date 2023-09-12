using ProductMgmt.Core;

namespace ProductMgmt.Infrastructure
{
    public interface IProductService
    {
        IReadOnlyList<Product> GetProductByCategory(string code);
        IReadOnlyList<Product> GetProductByCodeOrName(string codeOrName);
        IReadOnlyList<Product> GetProducts();
        void Add(Product product);
    }
}