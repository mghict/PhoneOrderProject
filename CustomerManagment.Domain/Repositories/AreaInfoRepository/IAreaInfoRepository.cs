using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IAreaInfoRepository : Base.IRepository<Models.AreaInfoTbl>
    {
        void InsertAreaGeo(Models.AreaGeoTbl dto);
        Task InserAreaGeoAsync(Models.AreaGeoTbl dto);

        void InsertAreaGeo(IList<Models.AreaGeoTbl> dto);
        Task InserAreaGeoAsync(IList<Models.AreaGeoTbl> dto);

    }
}
