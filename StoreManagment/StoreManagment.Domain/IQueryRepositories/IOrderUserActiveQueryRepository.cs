using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace StoreManagment.Domain.IQueryRepositories
{
    public interface IOrderUserActiveQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerPreOrderUserActive, long>
    {
        Task<List<Domain.Entities.CustomerPreOrderUserActive>> GetOrderUserActivityDetailsinCurrentDate(int userId);
        Task<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> GetOrderUserActivitySummeryinCurrentDate(int userId);
        Task<List<Domain.Entities.CustomerPreOrderUserActiveSummery>> GetOrderUserActivitySummeryInDate(DateTime orderDate,float storeId=0,int userId=0,int roleId=0);
        Task<List<Domain.Entities.CustomerPreOrderUserActive>> GetOrderUserActivityDetailsInDate(DateTime orderDate, float storeId = 0, int userId = 0);
        Task<List<Domain.Entities.UserActivityLogs>> GetOrderUserActivityLogs(DateTime fromDate,DateTime toDate, int userId=0);
        Task<List<Domain.Entities.OrderUserActivityByStatus>> GetOrderUserActivityByStatus(int userId, int status);
        Task<List<Domain.Entities.OrderUserActivityByStatus>> GetOrderUserActivityByStatusItems(int userId, int status,int itemStatus);

    }
}
