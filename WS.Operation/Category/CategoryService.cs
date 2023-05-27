using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Data.Domain;
using WS.Data.UnitOfWork;
using WS.Operation.Base;
using WS.Schema.Category;

namespace WS.Operation
{
    public class CategoryService : BaseService<Category, CategoryRequest, CategoryResponse>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


    }
}



