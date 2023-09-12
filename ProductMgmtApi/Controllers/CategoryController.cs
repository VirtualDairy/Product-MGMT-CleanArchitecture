using Microsoft.AspNetCore.Mvc;
using ProductMgmt.Core;
using ProductMgmt.Infrastructure;

namespace ProductMgmtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            return categoryService.GetCategories();
        }

        [HttpGet("/{code}")]
        public IEnumerable<ProductCategory> Get(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new BadRequestException("code can't be NULL");
            }

            return categoryService.GetCategories(code);
        }

        [HttpPost]
        public void Add(ProductCategory category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Code) || category?.SubCategoryCodes.Any() == false)
            {
                throw new BadRequestException("Required fields are missing");
            }

            categoryService.AddCategory(category);
        }
    }
}
