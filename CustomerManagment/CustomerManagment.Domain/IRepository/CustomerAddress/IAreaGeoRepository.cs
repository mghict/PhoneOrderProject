using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerAddress
{
    public interface IAreaGeoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.AreaGeoTbl,long>
    {

    }
}
