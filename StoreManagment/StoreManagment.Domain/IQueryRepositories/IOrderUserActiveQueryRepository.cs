using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IQueryRepositories
{
    public interface IOrderUserActiveQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerPreOrderUserActive, long>
    {
        Task<List<Domain.Entities.CustomerPreOrderUserActive>> GetOrderUserActivityDetailsinCurrentDate(int userId);
        Task<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> GetOrderUserActivitySummeryinCurrentDate(int userId);
    }
}
