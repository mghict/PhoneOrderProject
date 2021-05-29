using SettingManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class ShippingGlobalPriceQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreGeneralShippingByPriceTbl, int>,
        Domain.IRepositories.Store.IShippingGlobalPriceQueryRepository
    {
        protected internal ShippingGlobalPriceQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<StoreGeneralShippingByPriceTbl>> GetByRange(int amount)
        {
            var query = "select * from StoreGeneralShippingByPriceTbl " + "" +
                        " where @Amount between FromSum and ToSum and" +
                        "       Status=1";
            var param = new
            {
                @Amount = amount
            };

            try
            {
                var result = await db.QueryAsync<StoreGeneralShippingByPriceTbl>(query, param);
                return result.ToList();

            }
            catch
            {
                return null;
            }
        }

        public async Task<List<StoreGeneralShippingByPriceTbl>> GetByRange(int fromAmount, int toAmount)
        {
            var query = "select * from StoreGeneralShippingByPriceTbl " + "" +
                        " where (@from between FromSum and ToSum   or " +
                        "        @to   between FromSum and ToSum ) and" +
                        "        Status=1";
            var param = new
            {
                @from=fromAmount,
                @to=toAmount
            };

            try
            {
                var result = await db.QueryAsync<StoreGeneralShippingByPriceTbl>(query, param);
                return result.ToList();

            }
            catch
            {
                return null;
            }
        }


    }
}
