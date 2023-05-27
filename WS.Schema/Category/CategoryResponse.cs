using WS.Base.Models;

namespace WS.Schema.Category
{
    public class CategoryResponse : BaseResponse
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
