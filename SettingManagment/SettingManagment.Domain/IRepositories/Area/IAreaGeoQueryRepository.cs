using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Area
{
    public interface IAreaGeoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.AreaGeoTbl, long>
    {
        Task<List<Entities.AreaGeoTbl>> GetByAreaId(int areaId);
    }
}
