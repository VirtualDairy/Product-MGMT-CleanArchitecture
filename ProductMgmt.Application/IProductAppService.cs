using ProductMgmt.Core;

namespace ProductMgmt.Application
{
    public interface IProductAppService
    {
        bool ValidateProduct(Product product);
    }
}