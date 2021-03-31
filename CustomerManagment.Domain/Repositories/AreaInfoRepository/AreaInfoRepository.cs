using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class AreaInfoRepository : Repository<Models.AreaInfoTbl>, IAreaInfoRepository
    {
        internal AreaInfoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }


        public async Task InserAreaGeoAsync(AreaGeoTbl dto)
        {
            if (dto == null)
            {
                return;
            }
            var entity = DbSet.Find(dto.AreaId);
            if (entity != null)
            {
                entity.AreaGeoTbls.Add(dto);

                await base.UpdateAsync(entity);
            }

            return;

        }

        public async Task InserAreaGeoAsync(IList<AreaGeoTbl> dto)
        {
            if (dto == null || dto.Count < 1)
            {
                return;
            }

            foreach (var item in dto)
            {
                var entity = DbSet.Find(item.AreaId);
                if (entity != null)
                {
                    entity.AreaGeoTbls.Add(item);
                    await base.UpdateAsync(entity);
                }

            }

        }

        public void InsertAreaGeo(AreaGeoTbl dto)
        {

            if (dto == null)
            {
                return;
            }
            var entity = DbSet.Find(dto.AreaId);
            if (entity == null)
            {
                return;
            }

            entity.AreaGeoTbls.Add(dto);

            DbSet.Update(entity);
        }

        public void InsertAreaGeo(IList<AreaGeoTbl> dto)
        {
            if (dto == null || dto.Count < 1)
            {
                return;
            }

            foreach (var item in dto)
            {
                var entity = DbSet.Find(item.AreaId);
                if (entity != null)
                {
                    entity.AreaGeoTbls.Add(item);
                    DbSet.Update(entity);


                }

            }
        }
    }
}
