using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.Province
{
    public interface IProvinceRepository:Base.IRepository<Models.ProvinceTbl,double>
    {
        Models.ProvinceTbl GetProvinceWithCities(double id);

        Task<Models.ProvinceTbl> GetProvinceWithCitiesAsync(double id);

        IEnumerable<Models.CityTbl> GetCities(double id);
        Task<IEnumerable<Models.CityTbl>> GetCitiesAsync(double id);
    }
}
