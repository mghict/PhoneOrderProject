using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.AreaInfo
{
    public class AreaInfoRepository : Repository<Models.AreaInfoTbl, int>, IAreaInfoRepository
    {

        internal AreaInfoRepository(IDbConnection _db) : base(_db)
        {
        }

        public AreaInfoTbl FindEager(int id)
        {
            var param = new
            {
                AreaId = id
            };

            var query = "SELECT * FROM AreaInfoTbl WHERE Id= @AreaId"+
                        " SELECT * FROM AreaGeoTbl WHERE AreaId= @AreaId";

            AreaInfoTbl entity;

            using (var lists = db.QueryMultiple(query, param))
            {
                entity = lists.Read<AreaInfoTbl>().ToList().FirstOrDefault();
                entity.AreaGeoTbls = lists.Read<AreaGeoTbl>().ToList();
            }

            return entity;
        }

        public async Task<AreaInfoTbl> FindEagerAsync(int id)
        {
            var param = new
            {
                AreaId = id
            };

            var query = " SELECT * FROM AreaInfoTbl WHERE Id= @AreaId " +
                        " SELECT * FROM AreaGeoTbl  WHERE AreaId= @AreaId ";

            AreaInfoTbl entity;

            using (var lists = await db.QueryMultipleAsync(query, param))
            {
                entity = lists.Read<AreaInfoTbl>().ToList().FirstOrDefault();
                entity.AreaGeoTbls = lists.Read<AreaGeoTbl>().ToList();
            }

            return entity;
        }
    }
}
