using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using System.Linq;
using BehsamFramework.Util;

namespace SettingManagment.Persistence.Repositories.TimeSheet
{
    public class TimeSheetQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.TimeSheet, int>,
        Domain.IRepositories.TimeSheet.ITimeSheetQueryRepository
    {
        protected internal TimeSheetQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<Domain.Entities.TimeSheet> GetTimeSheet(DateTime requestDate)
        {
            var day = requestDate.GetDayOfWeekPersian();
            Domain.Entities.TimeSheet entity = new Domain.Entities.TimeSheet();
            try
            {
                entity =db.QueryFirstAsync<Domain.Entities.TimeSheet>("exec dbo.GetTimeSheet @RequestDate, @day  ", new { RequestDate = requestDate, day = day }).Result;
            }
            catch(Exception ex)
            {
                entity = new Domain.Entities.TimeSheet();
            }
            return entity;
        }
    }
}
