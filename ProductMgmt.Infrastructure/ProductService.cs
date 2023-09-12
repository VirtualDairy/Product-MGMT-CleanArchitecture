using ProductMgmt.Core;

namespace ProductMgmt.Infrastructure
{
    internal class ProductService : IProductService
    {
        private readonly ProductContext productContext;

        public ProductService(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public void Add(Product product)
        {
            if (productContext.Products.Any(x => x.Code.Equals(product.Code)))
            {
                throw new DuplicateException($"Product code: {product.Code} can not be duplicate");
            }

            productContext.Products.Add(product);
            productContext.SaveChanges();
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return this.productContext.Products.ToList();
        }

        public IReadOnlyList<Product> GetProductByCodeOrName(string codeOrName)
        {
            return this.productContext.Products.Where(x=>x.Name.Contains(codeOrName, StringComparison.OrdinalIgnoreCase) || x.Code.Contains(codeOrName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IReadOnlyList<Product> GetProductByCategory(string code)
        {
            return this.productContext.Products.Where(x => x.CategoryCode.Contains(code, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}