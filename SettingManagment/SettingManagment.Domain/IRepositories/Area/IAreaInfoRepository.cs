using System;
using System.Linq;
using System.Text;

namespace SettingManagment.Domain.IRepositories.Area
{
    public interface IAreaInfoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.AreaInfoTbl,int>
    {
    }
}
