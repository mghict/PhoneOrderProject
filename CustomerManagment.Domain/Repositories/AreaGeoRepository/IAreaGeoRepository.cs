using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IAreaGeoRepository : Base.IRepository<Models.AreaGeoTbl>
    {
        List<Models.AreaGeoTbl> GetAreaPoints(int areaId);
        Task<List<Models.AreaGeoTbl>> GetAreaPointsAsync(int areaId);

        void InsertList(List<Models.AreaGeoTbl> entities);
        Task InsertListAsync(List<Models.AreaGeoTbl> entities);
    }
}
