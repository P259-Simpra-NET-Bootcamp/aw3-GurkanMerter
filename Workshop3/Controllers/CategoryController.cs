using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS.Base.Response;
using WS.Operation;
using WS.Schema.Category;
using WS.Schema.Product;

namespace Workshop3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ApiResponse<List<CategoryResponse>> GetAll()
        {
            var customerList = _categoryService.GetAll();
            return customerList;
        }

        [HttpGet("{id}")]
        public ApiResponse<CategoryResponse> GetById(int id)
        {
            var customer = _categoryService.GetById(id);
            return customer;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] CategoryRequest request)
        {
            return _categoryService.Insert(request);
        }

        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] CategoryRequest request)
        {
            return _categoryService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            return _categoryService.Delete(id);
        }
    }
}
