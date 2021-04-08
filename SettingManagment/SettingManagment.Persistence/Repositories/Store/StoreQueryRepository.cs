using BehsamFramework.Util;
using SettingManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using BehsamFramework.Models;
using System.Globalization;

namespace SettingManagment.Persistence.Repositories.Store
{
    public class StoreQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreInfoTbl, float>,
        Domain.IRepositories.Store.IStoreQueryRepository
    {
        protected internal StoreQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<StoreInfoListModel> GetStoreByPaginationAsync(int pageNumber, int pageSize, string search)
        {
            var query = "Select APPROX_COUNT_DISTINCT(StoreCode) as StoreCount  FROM dbo.StoreInfoTbl ;";

            var builder = new SqlBuilder();
            

            if (!string.IsNullOrEmpty(search))
            {
                float storeId = 0;
                System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowDecimalPoint;
                System.Globalization.CultureInfo info = System.Globalization.CultureInfo.InvariantCulture;
                if (float.TryParse(search, style,info, out storeId))
                {
                    builder.Where($" (a.StoreName like '%{search}%' or Round(a.StoreCode,3)=Round({storeId.ToString(CultureInfo.InvariantCulture)},3) )");
                }
                else
                {
                    builder.Where($" a.StoreName like '%{search}%' ");
                }

            }

            var qu = builder.AddTemplate("select a.[StoreCode] , a.[StoreName] , a.[StoreAddress], a.[StorePhone]"+
            ", a.[Latitude] , a.[Longitude] , a.[AreaID], coalesce(b.AreaName,'') AreaName , coalesce( c.CityName,'')CityName ,coalesce( p.ProvinceName,'') ProvinceName  FROM " +
            "[PhoneOrderDB].[dbo].[StoreInfoTbl] a " +
            " left outer join " +
            "[dbo].[AreaInfoTbl] b " +
            "on   a.AreaID = b.ID " +
            "left outer join " +
            "[dbo].[CityTbl] c " +
            "on b.CityId = c.Id " +
            " left outer join [dbo].[ProvinceTbl] p  " +
            " on p.Id = c.ProvinceId " +
            "  /**where**/ order by a.StoreCode OFFSET @PageNumer ROWS FETCH NEXT @PageSize ROWS ONLY");
            query += qu.RawSql;

            pageNumber = pageNumber - 1;
            var param = new
            {
                @PageNumer = pageNumber <= 0 ? 0 : pageNumber,
                @PageSize = pageSize
            };

            StoreInfoListModel storeList = new StoreInfoListModel();
            storeList.Stores = new List<StoreOrderModel>();

            using (var list = await db.QueryMultipleAsync(query, param))
            {
                storeList.RowCount = list.ReadFirst<long>();
                var temp = list.Read<StoreOrderModel>().ToList();
                storeList.Stores.AddRange(temp);

            }

            return storeList;
        }

        public async Task<IList<Stores>> GetStoresAsync(DateTime requestDate, TimeSpan start, TimeSpan end, long customerId)
        {
            var day = requestDate.GetDayOfWeekPersian();
            var query = "exec dbo.GetStores @StartTime,@EndTime,@CustomerId,@RequestDate,@Day ";
            List<Stores> entity = new List<Stores>();
            
            try
            {
                var result =await db.QueryAsync<Stores>(query, new { StartTime= start, EndTime= end, CustomerId= customerId, RequestDate = requestDate, Day = day });
                entity = result.ToList();
            }
            catch (Exception ex)
            {
                entity = new List<Stores>();
            }

            return entity;
        }
    }
}
