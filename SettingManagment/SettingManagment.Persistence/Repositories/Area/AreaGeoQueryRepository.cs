using SettingManagment.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.Area
{
    public class AreaGeoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.AreaGeoTbl, long>,
        Domain.IRepositories.Area.IAreaGeoQueryRepository
    {
        protected internal AreaGeoQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<AreaGeoTbl>> GetByAreaId(int areaId)
        {
            var query = "Select * from dbo.AreaGeoTbl where AreaID=@area and Status=1";
            var param = new
            {
                @area = areaId
            };

            var lst = await db.QueryAsync<AreaGeoTbl>(query, param);
            return lst.ToList();
        }
    }
}
