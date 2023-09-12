using ProductMgmt.Core;

namespace ProductMgmt.Application
{
    internal class ProductAppService : IProductAppService
    {
        public bool ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new UnprocessableException("Product name is NULL or Empty");

            if (product.Quantity < 0)
                throw new UnprocessableException("Product Quantity is Zero");

            return true;
        }
    }
}