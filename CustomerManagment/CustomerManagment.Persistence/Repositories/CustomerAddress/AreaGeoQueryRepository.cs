using System.Data;

namespace CustomerManagment.Persistence.Repositories.CustomerAddress
{
    public class AreaGeoQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.AreaGeoTbl, long>,
        Domain.IRepository.CustomerAddress.IAreaGeoQueryRepository
    {
        protected internal AreaGeoQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
