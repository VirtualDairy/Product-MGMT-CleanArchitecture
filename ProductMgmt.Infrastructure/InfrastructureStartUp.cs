using Microsoft.Extensions.DependencyInjection;

namespace ProductMgmt.Infrastructure
{
    public static class InfrastructureStartUp
    {
        public static void UseInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ProductContext>(provider =>
            {
                var productContext = new ProductContext();
                //MockData.LoadMockProducts(productContext);
                //MockData.LoadMockCategories(productContext);
                return productContext;
            });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
