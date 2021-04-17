using System;
using System.Data;
using System.Text;

namespace SettingManagment.Persistence.Repositories.Area
{
    public class AreaInfoReposiroty :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.AreaInfoTbl, int>,
        Domain.IRepositories.Area.IAreaInfoRepository
    {
        protected internal AreaInfoReposiroty(IDbConnection _db) : base(_db)
        {
        }
    }
}
