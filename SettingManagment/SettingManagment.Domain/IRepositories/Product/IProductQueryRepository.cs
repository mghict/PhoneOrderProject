using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Product
{
    public interface IProductQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.ProductInfoTbl,int>
    {
        Task<List<BehsamFramework.Models.ProductShowModel>> GetProductByCatAndStoreAsync(float catId, float storeId);

        Task<List<BehsamFramework.Models.ProductShowModel>> GetProductByCatgoryAsync(float catId);
    }
}
