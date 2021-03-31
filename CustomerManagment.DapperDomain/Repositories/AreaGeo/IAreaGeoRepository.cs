using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.AreaGeo
{
    public interface IAreaGeoRepository:Base.IRepository<Models.AreaGeoTbl,int>
    {
        IEnumerable<Models.AreaGeoTbl> GetByAreaId(int areaId);
        Task<IEnumerable<Models.AreaGeoTbl>> GetByAreaIdAsync(int areaId);

        IEnumerable<Models.AreaGeoTbl> GetByAreaIdEagerLoad(int areaId);
        Task<IEnumerable<Models.AreaGeoTbl>> GetByAreaIdEagerLoadAsync(int areaId);
    }
}
