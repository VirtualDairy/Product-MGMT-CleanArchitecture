using Microsoft.AspNetCore.Mvc;
using ProductMgmt.Application;
using ProductMgmt.Core;
using ProductMgmt.Infrastructure;

namespace ProductMgmtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService productService;
        private readonly IProductAppService productAppService;

        public ProductController(ILogger<ProductController> logger, IProductService productService, IProductAppService productAppService)
        {
            _logger = logger;
            this.productService = productService;
            this.productAppService = productAppService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        [HttpGet("getbycodeOrName/{codeOrName}")]
        public IEnumerable<Product> GetByCodeOrName(string codeOrName)
        {
            if (string.IsNullOrWhiteSpace(codeOrName))
            {
                throw new BadRequestException("codeOrName can't be NULL");
            }

            return productService.GetProductByCodeOrName(codeOrName);
        }

        [HttpGet("getbycategory/{category}")]
        public IEnumerable<Product> BetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new BadRequestException("category can't be NULL");
            }

            return productService.GetProductByCategory(category);
        }

        [HttpPost]
        public void Add(Product product)
        {
            if (product == null || string.IsNullOrWhiteSpace(product.Code))
            {
                throw new BadRequestException("Product code can't be NULL");
            }

            productAppService.ValidateProduct(product);
            productService.Add(product);
        }
    }
}