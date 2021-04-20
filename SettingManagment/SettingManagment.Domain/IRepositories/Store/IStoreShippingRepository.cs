using System;
using System.Linq;
using System.Text;

namespace SettingManagment.Domain.IRepositories.Store
{
    public interface IStoreShippingRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.StoreShippingTbl,int>
    {
    }
}
