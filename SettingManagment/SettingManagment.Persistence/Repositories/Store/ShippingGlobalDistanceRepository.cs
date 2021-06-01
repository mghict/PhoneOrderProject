using SettingManagment.Domain.Entities;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class ShippingGlobalDistanceRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreGeneralShippingByDistanceTbl, int>,
        Domain.IRepositories.Store.IShippingGlobalDistanceRepository
    {
        protected internal ShippingGlobalDistanceRepository(IDbConnection _db) : base(_db)
        {
        }

        public override async Task<StoreGeneralShippingByDistanceTbl> InsertAsync(StoreGeneralShippingByDistanceTbl entity)
        {
            var exist = await ExistsInRangeAsync(entity.FromDistance, entity.ToDistance);
            if (exist == 0)
            {
                return await base.InsertAsync(entity);
            }
            else
            {
                return null;
            }
        }

        public override async Task<bool> UpdateAsync(StoreGeneralShippingByDistanceTbl obj)
        {
            //var exist = await ExistsInRangeAsync(obj.FromDistance, obj.ToDistance);
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

        public async Task<int> ExistsInRangeAsync(int fromDistance, int toDistance)
        {
            var query = "select * from StoreGeneralShippingByDistanceTbl " +
                        " where @fromDistance between FromDistance and ToDistance or " +
                        "       @toDistance between FromDistance and ToDistance ";
            var param = new
            {
                @fromDistance = fromDistance,
                @toDistance = toDistance
            };
           
            try
            {
                var item = await db.QueryFirstOrDefaultAsync<StoreGeneralShippingByDistanceTbl>(query, param);

                if (item == null)
                {
                    return 0;
                }

                if (item.ToDistance == fromDistance)
                {
                    return 0;
                }

                return item.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
