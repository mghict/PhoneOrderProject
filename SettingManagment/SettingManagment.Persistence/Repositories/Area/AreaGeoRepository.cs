using SettingManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Persistence.Repositories.Area
{
    public class AreaGeoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.AreaGeoTbl, long>,
        Domain.IRepositories.Area.IAreaGeoRepository
    {

        protected internal AreaGeoRepository(IDbConnection _db) : base(_db)
        {
        }

        private void delete(int areaId)
        {
                var query = "delete from AreaGeoTbl where AreaID=@AreaID";
                var param = new
                {
                    @AreaID = areaId
                };

                var lst = db.Execute(query, param);
        }

        public override AreaGeoTbl Insert(AreaGeoTbl obj)
        {
            delete(obj.AreaId);

            var rest=base.Insert(obj);

            return rest;
        }
        public override async Task<AreaGeoTbl> InsertAsync(AreaGeoTbl entity)
        {
            delete(entity.AreaId);

            var rest =await base.InsertAsync(entity);

            return rest;
        }

        public override int InsertEnumerable(IEnumerable<AreaGeoTbl> list)
        {
            int countInsert = 0;

            delete(list.FirstOrDefault().AreaId);

            countInsert = base.InsertEnumerable(list);

            return countInsert;
        }
        public override async Task<int> InsertEnumerableAsync(IEnumerable<AreaGeoTbl> list)
        {
            int countInsert = 0;

            delete(list.FirstOrDefault().AreaId);

            countInsert=await base.InsertEnumerableAsync(list);

            return countInsert;
        }
    }
}
