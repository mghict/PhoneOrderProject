using System.Data;

namespace SettingManagment.Persistence.Repositories.Area
{
    public class ProvinceQueryRepository :
        BehsamFramework.DapperDomain.QueryRepository<Domain.Entities.ProvinceTbl, float>,
        Domain.IRepositories.Area.IProvinceQueryRepository
    {
        protected internal ProvinceQueryRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
