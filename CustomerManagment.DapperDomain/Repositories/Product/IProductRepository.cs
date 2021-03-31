using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.Product
{
    public interface IProductRepository : Base.IRepository<Models.ProductInfoTbl, int>
    {
        
    }
}
