using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Base.Response;
using WS.Operation;
using WS.Schema.Product;

namespace Workshop3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService= productService;
        }

        [HttpGet]
        public ApiResponse<List<ProductResponse>> GetAll()
        {
            var customerList = _productService.GetAll();
            return customerList;
        }

        [HttpGet("{id}")]
        public ApiResponse<ProductResponse> GetById(int id)
        {
            var customer = _productService.GetById(id);
            return customer;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] ProductRequest request)
        {
            return _productService.Insert(request);
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] ProductRequest request)
        {
            return _productService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return _productService.Delete(id);
        }
    }
}
