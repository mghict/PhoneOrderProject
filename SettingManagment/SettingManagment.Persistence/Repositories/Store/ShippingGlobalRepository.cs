using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class ShippingGlobalRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreGeneralShippingTbl, byte>,
        Domain.IRepositories.Store.IShippingGlobalRepository
    {
        protected internal ShippingGlobalRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
