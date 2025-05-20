using CustomBasePattern.Dtos;
using CustomBasePattern.Entities;
using CustomBasePattern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomBasePattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService; 
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetPaginated([FromQuery] ProductQueryParams query)
        {
            var products = _productService.GetPaginatedProducts(query.PageNumber, query.PageSize, out int totalCount);

            var pagination = new
            {
                query.PageNumber,
                query.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / query.PageSize)
            };

            return SuccessResponse(products, "Products retrieved successfully.", pagination);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return ErrorResponse("Product not found.");
            return SuccessResponse(product, "Product retrieved successfully.");
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return ValidationErrorResponse();

            _productService.AddProduct(product);
            return SuccessResponse(product, "Product created successfully.");
        }

    }
}
