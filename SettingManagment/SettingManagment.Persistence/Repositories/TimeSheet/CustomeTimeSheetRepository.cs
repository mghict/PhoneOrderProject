using System.Data;

namespace SettingManagment.Persistence.Repositories.TimeSheet
{
    public class CustomeTimeSheetRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.StoreCustomeTimeSheetTbl, int>,
        Domain.IRepositories.TimeSheet.ICustomeTimeSheetRepository
    {
        protected internal CustomeTimeSheetRepository(IDbConnection _db) : base(_db)
        {
        }
    }


}
