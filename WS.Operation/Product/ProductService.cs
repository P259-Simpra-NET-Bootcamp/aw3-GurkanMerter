using AutoMapper;
using WS.Data.Domain;
using WS.Data.UnitOfWork;
using WS.Operation.Base;
using WS.Schema.Product;

namespace WS.Operation
{
    public class ProductService : BaseService<Product, ProductRequest, ProductResponse>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}


