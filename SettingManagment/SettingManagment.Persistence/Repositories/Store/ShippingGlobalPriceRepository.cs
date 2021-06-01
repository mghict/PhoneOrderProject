using SettingManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class ShippingGlobalPriceRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreGeneralShippingByPriceTbl, int>,
        Domain.IRepositories.Store.IShippingGlobalPriceRepository
    {
        protected internal ShippingGlobalPriceRepository(IDbConnection _db) : base(_db)
        {
        }

        public override async Task<StoreGeneralShippingByPriceTbl> InsertAsync(StoreGeneralShippingByPriceTbl entity)
        {
            var exist = await ExistsInRangeAsync(entity.FromSum,entity.ToSum);
            if (exist==0)
            {
                return await base.InsertAsync(entity);
            }
            else
            {
                return null;
            }
        }

        public override async Task<bool> UpdateAsync(StoreGeneralShippingByPriceTbl obj)
        {
            //var exist = await ExistsInRangeAsync(obj.FromSum, obj.ToSum);
            //if (exist == obj.Id)
            //{
            //    return await base.UpdateAsync(obj);
            //}
            //else
            //{
            //    return false;
            //}

            return await base.UpdateAsync(obj);
        }

        public async Task<int> ExistsInRangeAsync(int fromSum, int toSum)
        {
            
            var query = " select * from StoreGeneralShippingByPriceTbl " +
                        " where @fromSum between FromSum and ToSum or " +
                        "       @toSum   between FromSum and ToSum ";
            var param = new
            {
                @fromSum = fromSum,
                @toSum = toSum
            };
            try
            {
                var item = await db.QueryFirstOrDefaultAsync<StoreGeneralShippingByPriceTbl>(query,param);
                
                if(item==null)
                {
                    return 0;
                }

                if(item.ToSum==fromSum)
                {
                    return 0;
                }

                return item.Id;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
