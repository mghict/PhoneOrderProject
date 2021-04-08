using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using BehsamFramework.Util;
using System.Collections.Generic;
using SettingManagment.Domain.Entities;

namespace SettingManagment.Persistence.Repositories.TimeSheet
{
    public class CustomeTimeSheetQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.StoreCustomeTimeSheetTbl, int>,
        Domain.IRepositories.TimeSheet.ICustomeTimeSheetQueryRepository
    {
        protected internal CustomeTimeSheetQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<IList<StoreCustomeTimeSheetTbl>> GetByStoreOrDate(DateTime requestDate, float StoreId)
        {
            var query = "Select * from StoreCustomeTimeSheetTbl where (RequestDate=@RequestDate or @RequestDate is null) and (Round(StoreId),3)=Round(@SotrId,3) or @SotrId=0.0)";
            var param = new
            {
                @RequestDate = requestDate == null ? DateTime.Now : requestDate,
                @StoreId = StoreId > 0 ? StoreId : 0.0f
            };

            var result = await db.QueryAsync<StoreCustomeTimeSheetTbl>(query, param);

            return result.ToList();
        }

    }
}
