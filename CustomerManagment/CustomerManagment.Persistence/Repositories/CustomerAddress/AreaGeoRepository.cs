using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class AreaGeoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.AreaGeoTbl, long>,
        Domain.IRepository.CustomerAddress.IAreaGeoRepository
    {
        protected internal AreaGeoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
