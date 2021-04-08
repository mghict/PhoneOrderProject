using System.Threading.Tasks;
using System;

namespace SettingManagment.Domain.IRepositories.TimeSheet
{
    public interface ITimeSheetQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.StoreTimeSheetTbl, byte>
    {
        Task<Entities.TimeSheet> GetTimeSheet(DateTime requestDate);
    }
}
