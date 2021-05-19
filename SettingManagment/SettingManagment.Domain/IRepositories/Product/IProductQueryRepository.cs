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

        Task<BehsamFramework.Models.ProductsModel> GetProducts(float storeId, string searchKey = "", float catId = 0, int pageNumber = 0, int pageSize = 20);
        Task<BehsamFramework.Models.ProductsModel> GetProductAll(string searchKey="", int pageNumber = 0, int pageSize = 20);
        Task<BehsamFramework.Models.ProductsModel> GetProductAllByStore(float storeId, string searchKey = "", int pageNumber = 0, int pageSize = 20);
        Task<BehsamFramework.Models.ProductReserveModel> GetProductReserve
            (long itemId,float storeId,bool categoryEqual=true,bool brandEqual=false,string brandSearch="",bool nameEqual=false,string nameSearch="",
             int pageNumber=0,int pageSize=20);
    }
}
