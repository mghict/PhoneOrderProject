using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DataDapper.Repositories.Province
{
    public class ProvinceRepository : Repository<Models.ProvinceTbl, double>, IProvinceRepository
    {
        private const string _GetProductWithCities = "select * from ProvinceTbl a where a.Id = @id " +
                                          "select * from CityTbl b where ProvinceId = @id ";

        private const string _GetCities= "select * from CityTbl b where ProvinceId = @id ";
        internal ProvinceRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }

        public ProvinceTbl GetProvinceWithCities(double id)
        {
            if(id==0)
            {
                return new ProvinceTbl();
            }

            ProvinceTbl province;

            using (var lists = db.QueryMultiple(_GetProductWithCities, new { @id=id}))
            {
                province = lists.Read<ProvinceTbl>().ToList().FirstOrDefault();
                province.CityTbls = lists.Read<CityTbl>().ToList();
            }


            return province;
        }

        public async Task<ProvinceTbl> GetProvinceWithCitiesAsync(double id)
        {
            ProvinceTbl province = new ProvinceTbl()
            {
                CityTbls = new List<CityTbl>()
            };
            if (id == 0)
            {
                return province;
            }

            

            using (var lists = await db.QueryMultipleAsync(_GetProductWithCities, new { @id = id }))
            {
                try
                {
                    province = lists.Read<ProvinceTbl>().ToList().FirstOrDefault();
                    province.CityTbls = lists.Read<CityTbl>().ToList();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return province;
        }

        public IEnumerable<CityTbl> GetCities(double id)
        {
            if (id == 0)
            {
                return null;
            }

            IEnumerable<CityTbl> city;

            city = db.Query<CityTbl>(_GetCities, new {@id = id}).ToList();
            


            return city;
        }

        public async Task<IEnumerable<CityTbl>> GetCitiesAsync(double id)
        {
            if (id == 0)
            {
                return null;
            }

            IEnumerable<CityTbl> city;

            city = (await db.QueryAsync<CityTbl>(_GetCities, new { @id = id })).ToList();



            return city;
        }
    }
}
