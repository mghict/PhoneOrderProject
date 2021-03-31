using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;

namespace SettingManagment.Persistence.Repositories.Product
{
    public class ProductQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.ProductInfoTbl, int>,
        Domain.IRepositories.Product.IProductQueryRepository
    {
        protected internal ProductQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<ProductShowModel>> GetProductByCatAndStoreAsync(float catId, float storeId)
        {
            
            var query = "SELECT a.* FROM[dbo].[ProductInfoTbl] a,[dbo].[StoreProductTbl] b " +
                " where  a.id = b.ProductID and a.Status = b.Status and a.Status = 1 and "+
                " a.CategotyID = @catId and b.StoreID = @storeId and b.Quantity > 0 ";

            var param = new DynamicParameters();
            param.Add("catId", catId, DbType.Decimal);
            param.Add("storeId", storeId, DbType.Decimal);


            var entity = await db.QueryAsync<ProductShowModel>(query, param);

            return entity.ToList();
        }

        public async Task<List<ProductShowModel>> GetProductByCatgoryAsync(float catId)
        {
            var query = "SELECT * FROM [dbo].[ProductInfoTbl] where CategotyID = @catId ";

            var param = new
            {
                @catId = catId
            };


            var entity =await db.QueryAsync<ProductShowModel>(query,param);

            return entity.ToList();
        }
    }
}
