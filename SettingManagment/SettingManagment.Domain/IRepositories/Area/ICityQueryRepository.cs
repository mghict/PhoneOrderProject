using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Area
{
    public interface ICityQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.CityTbl,int>
    {
        Task<List<Domain.Entities.CityTbl>> GetByProvince(float provinceId);
    }
}
