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
    public class CityQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.CityTbl, int>,
        Domain.IRepositories.Area.ICityQueryRepository
    {
        protected internal CityQueryRepository(IDbConnection _db) : base(_db)
        {
        }

        public async Task<List<CityTbl>> GetByProvince(float provinceId)
        {
            var query = "select * from CityTbl where Round(ProvinceId,3)=Round(@pId,3)";
            var param = new
            {
                @pId = provinceId
            };

            var lst = await db.QueryAsync<CityTbl>(query, param);

            return lst.ToList();
        }
    }
}
