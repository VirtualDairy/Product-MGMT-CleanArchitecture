using ProductMgmt.Core;

namespace ProductMgmt.Infrastructure
{
    public interface ICategoryService
    {
        void AddCategory(ProductCategory category);
        IReadOnlyList<ProductCategory> GetCategories();
        IReadOnlyList<ProductCategory> GetCategories(string code);
        bool IsExist(string code, string subcode);
    }
}