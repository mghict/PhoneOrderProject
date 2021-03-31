using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Mapper;

namespace DataDapper.Repositories.AreaGeo
{
    public class AreaGeoRepository:Repository<Models.AreaGeoTbl,int>,IAreaGeoRepository
    {
        private const string _getByAreaId = "select * from areageotbl where areaid=@areaid";
        private const string _getByAreaIdEager = "select a.*,b.* from areageotbl a,areainfotbl b where a.areaid=@areaid and a.areaid=b.id";
        internal AreaGeoRepository(IDbConnection _db) : base(_db)
        {
        }

        public IEnumerable<AreaGeoTbl> GetByAreaId(int areaId)
        {
            return db.Query<AreaGeoTbl>(_getByAreaId, new { @areaid = areaId });
        }

        public async Task<IEnumerable<AreaGeoTbl>> GetByAreaIdAsync(int areaId)
        {
            return await db.QueryAsync<AreaGeoTbl>(_getByAreaId, new { @areaid = areaId });

        }

        public IEnumerable<AreaGeoTbl> GetByAreaIdEagerLoad(int areaId)
        {
            return db.Query<AreaGeoTbl, AreaInfoTbl>(_getByAreaIdEager, new { @areaid = areaId });
        }

        public async Task<IEnumerable<AreaGeoTbl>> GetByAreaIdEagerLoadAsync(int areaId)
        {
            return await db.QueryAsync<AreaGeoTbl, AreaInfoTbl>(_getByAreaIdEager, new { @areaid = areaId });
        }
    }
}
