using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.Product
{
    public class ProductRepository : Repository<Models.ProductInfoTbl, int>, IProductRepository
    {
        internal ProductRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
