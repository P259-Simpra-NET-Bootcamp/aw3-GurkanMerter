using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Data.Domain;
using WS.Operation.Base;
using WS.Schema.Product;

namespace WS.Operation
{

    public interface IProductService : IBaseService<Product, ProductRequest, ProductResponse>
    {

    }
}

