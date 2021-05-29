using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IShippingGlobalQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreGeneralShippingTbl,byte>
    {
    }
}
