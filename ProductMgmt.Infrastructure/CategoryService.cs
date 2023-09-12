using ProductMgmt.Core;
namespace ProductMgmt.Infrastructure
{
    internal class CategoryService : ICategoryService
    {
        private readonly ProductContext productContext;

        public CategoryService(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public IReadOnlyList<ProductCategory> GetCategories()
        {
            var categories = productContext.Categories.ToList();
            return categories.GroupBy(x => x.Code)
                 .Select(x => new ProductCategory() { Code = x.Key, SubCategoryCodes = x.Select(x => x.SubCategoryCode).ToList() })
                 .ToList();
        }

        public IReadOnlyList<ProductCategory> GetCategories(string code)
        {
            var categories = productContext.Categories.Where(x => x.Code.Contains(code, StringComparison.OrdinalIgnoreCase)).ToList();
            return categories.GroupBy(x => x.Code)
                .Select(x => new ProductCategory() { Code = x.Key, SubCategoryCodes = x.Select(x => x.SubCategoryCode).ToList() })
                .ToList();
        }

        public bool IsExist(string code, string subcode)
        {
            return productContext.Categories.Any(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase) || x.SubCategoryCode.Equals(subcode, StringComparison.OrdinalIgnoreCase));
        }

        public void AddCategory(ProductCategory category)
        {
            var cat = new List<Category>();

            foreach (var item in category.SubCategoryCodes)
            {
                cat.Add(new Category() { Code = category.Code, SubCategoryCode = item });
            }

            productContext.Categories.AddRange(cat);
            productContext.SaveChanges();
        }
    }
}
