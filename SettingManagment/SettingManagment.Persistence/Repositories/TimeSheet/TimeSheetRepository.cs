using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Persistence.Repositories.TimeSheet
{
    public class TimeSheetRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreTimeSheetTbl, byte>,
        Domain.IRepositories.TimeSheet.ITimeSheetRepository
    {
        protected internal TimeSheetRepository(IDbConnection _db) : base(_db)
        {
        }
    }


}
