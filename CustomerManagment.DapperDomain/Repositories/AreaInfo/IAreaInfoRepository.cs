using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.AreaInfo
{
    public interface IAreaInfoRepository:Base.IRepository<Models.AreaInfoTbl,int>
    {
        Models.AreaInfoTbl FindEager(int id);
        Task<Models.AreaInfoTbl> FindEagerAsync(int id);
    }
}
