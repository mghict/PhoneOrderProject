using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.CityInfo
{
    class CityRepository : Repository<Models.CityTbl, int>, ICityInfoRepository
    {
        internal CityRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
