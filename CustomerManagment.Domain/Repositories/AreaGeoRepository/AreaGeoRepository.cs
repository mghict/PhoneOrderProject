using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class AreaGeoRepository : Repository<Models.AreaGeoTbl>, IAreaGeoRepository
    {
        internal AreaGeoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public List<AreaGeoTbl> GetAreaPoints(int areaId)
        {
            var result = DbSet.Where(current => current.AreaId == areaId).ToList();

            return result;
        }

        public Task<List<AreaGeoTbl>> GetAreaPointsAsync(int areaId)
        {
            //List<AreaGeoTbl> result = new List<AreaGeoTbl>();

            //await System.Threading.Tasks.Task.Run(() =>
            //{
            //    result=DbSet.Where(current => current.AreaId == areaId).ToList();

            //});

            var result = DbSet.Where(current => current.AreaId == areaId).ToListAsync();
            return result;
        }

        public void InsertList(List<AreaGeoTbl> entities)
        {
            if (entities == null || entities.Count < 1)
            {
                return;
            }

            DbSet.AddRange(entities);

        }

        public async Task InsertListAsync(List<AreaGeoTbl> entities)
        {
            if (entities == null || entities.Count < 1)
            {
                return;
            }

            await DbSet.AddRangeAsync(entities);
        }
    }
}
