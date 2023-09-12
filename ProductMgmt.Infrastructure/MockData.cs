using ProductMgmt.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductMgmt.Infrastructure
{
    internal static class MockData
    {
        public static void LoadMockProducts(ProductContext productContext)
        {
            using StreamReader reader = new($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/Products.json");
            var json = reader.ReadToEnd();
            productContext.Products.AddRange(JsonSerializer.Deserialize<List<Product>>(json));
            productContext.SaveChanges();
        }

        public static void LoadMockCategories(ProductContext productContext)
        {
            using StreamReader reader = new($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/Categories.json");
            var json = reader.ReadToEnd();
            productContext.Categories.AddRange(JsonSerializer.Deserialize<List<Category>>(json));
            productContext.SaveChanges();
        }
    }
}
