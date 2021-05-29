using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSites.Panles.Helper;
using WebSites.Panles.Models.Reports;

namespace WebSites.Panles.Services.Reports
{
    public interface IReportsService
    {
        Task<FluentResult<List<Models.Reports.GetSummeryOrderByDate>>> GetSummeryOrderByDate(DateTime startDate, DateTime endDate);
        Task<FluentResult<List<Models.Reports.GetSummeryOrderStatusByDate>>> GetSummeryOrderStatusByDate(float storeId, DateTime startDate, DateTime endDate);
        Task<FluentResult<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>>> GetSummeryOrderStatusDetailsByDate(float storeId, DateTime startDate, DateTime endDate, int status);
        Task<FluentResult<List<Models.Reports.GetOrderDetailsByUserId>>> GetOrderDetailsByUserId(DateTime startDate, DateTime endDate, float storeId=0.0f,int userId=0 );
        Task<FluentResult<Models.Reports.GetOrderInfoWithItems>> GetOrderInfoWithItems(long orderCode);
        Task<FluentResult<List<Models.Reports.GetDetailsOrdersByDateAndStore>>> GetDetailsOrdersByDateAndStore(float storeId, DateTime orderDate, string orderTime);
        Task<FluentResult<List<Models.Reports.GetSummeryOrdersByDateAndStore>>> GetSummeryOrdersByDateAndStore(float storeId, DateTime orderDate);
        Task<FluentResult<List<Models.Order.CustomerPreOrderUserActive>>> GetUserActivityDetailsInDate(DateTime orderDate, float storeId = 0.0f, int userId = 0);
        Task<FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>> GetUserActivitySummeryInDate(DateTime orderDate, float storeId = 0.0f, int userId = 0, int roleId = 0);
        Task<List<Models.Order.UserActivityOrderLogs>> GetUserAvtivityOrderLogs(DateTime fromDate, DateTime toDate, int userId = 0);
        Task<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>> GetCustomerOrder(long customerId, DateTime startDate, DateTime endDate);
    }

    public class ReportsService : Base.ServiceBase, IReportsService
    {
        public ReportsService(ICacheService cacheService, ServiceCaller serviceCaller, IHttpClientFactory clientFactory, IMapper mapper) : base(cacheService, serviceCaller, clientFactory, mapper)
        {
        }

        public async Task<FluentResult<List<GetOrderDetailsByUserId>>> GetOrderDetailsByUserId(DateTime startDate, DateTime endDate, float storeId = 0.0f, int userId = 0)
        {
            var command = new
            {
                StartDate = startDate,
                EndDate = endDate,
                StoreId=storeId,
                UserId=userId
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetOrderDetailsByUserId>>("Order/Order/GetOrderDetailsByUserId", command);

            return result;
        }

        public async Task<FluentResult<GetOrderInfoWithItems>> GetOrderInfoWithItems(long orderCode)
        {
            var command = new
            {
                OrderCode=orderCode
            };

            var result = await ServiceCaller.PostDataWithValue<Models.Reports.GetOrderInfoWithItems>("Order/Order/GetOrderInfoWithItems", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Reports.GetSummeryOrderByDate>>> GetSummeryOrderByDate(DateTime startDate,DateTime endDate)
        {
            var command = new
            {
                StartDate = startDate,
                EndDate = endDate
            };

            var result =await ServiceCaller.PostDataWithValue<List<Models.Reports.GetSummeryOrderByDate>>("Order/Order/GetSummeryOrderByDate", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Reports.GetSummeryOrderStatusByDate>>> GetSummeryOrderStatusByDate(float storeId, DateTime startDate, DateTime endDate)
        {
            var command = new
            {
                StoreId=storeId,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetSummeryOrderStatusByDate>>("Order/Order/GetSummeryOrderStatusByDate", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>>> GetSummeryOrderStatusDetailsByDate(float storeId, DateTime startDate, DateTime endDate,int status)
        {
            var command = new
            {
                StoreId = storeId,
                StartDate = startDate,
                EndDate = endDate,
                Status=status
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>>("Order/Order/GetSummeryOrderStatusDetailsByDate", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Reports.GetSummeryOrdersByDateAndStore>>> GetSummeryOrdersByDateAndStore(float storeId, DateTime orderDate)
        {
            var command = new
            {
                StoreId = storeId,
                OrderDate = orderDate
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetSummeryOrdersByDateAndStore>>("Order/Order/GetSummeryOrdersByDateAndStore", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Reports.GetDetailsOrdersByDateAndStore>>> GetDetailsOrdersByDateAndStore(float storeId, DateTime orderDate,string orderTime)
        {
            var command = new
            {
                StoreId = storeId,
                OrderDate = orderDate,
                OrderTime=orderTime
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetDetailsOrdersByDateAndStore>>("Order/Order/GetDetailsOrdersByDateAndStore", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Order.CustomerPreOrderUserActive>>> GetUserActivityDetailsInDate( DateTime orderDate, float storeId=0.0f,int userId=0)
        {
            var command = new
            {
                UserId = userId,
                OrderDate = orderDate,
                StoreId = storeId
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Order.CustomerPreOrderUserActive>>("Order/UserActive/GetUserActivityDetailsInDate", command);

            return result;
        }

        public async Task<FluentResult<List<Models.Order.CustomerPreOrderUserActiveSummery>>> GetUserActivitySummeryInDate(DateTime orderDate, float storeId = 0.0f, int userId = 0,int roleId=0)
        {
            var command = new
            {
                UserId = userId,
                OrderDate = orderDate,
                StoreId = storeId,
                RoleId=roleId
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Order.CustomerPreOrderUserActiveSummery>>("Order/UserActive/GetUserActivitySummeryInDate", command);

            return result;
        }

        public async Task<List<Models.Order.UserActivityOrderLogs>> GetUserAvtivityOrderLogs(DateTime fromDate, DateTime toDate, int userId = 0)
        {
            FluentResult<List<Models.Order.UserActivityOrderLogs>> result =
                new FluentResult<List<Models.Order.UserActivityOrderLogs>>();

            result.IsFailed = true;

            var command = new
            {
                UserId = userId,
                FromDate = fromDate,
                ToDate = toDate
            };

            try
            {
                result = await ServiceCaller.PostDataWithValue<List<Models.Order.UserActivityOrderLogs>>("Order/UserActive/GetUserActivityOrderLogs", command);
            }
            catch (Exception ex)
            {
                result = new FluentResult<List<Models.Order.UserActivityOrderLogs>>();
                result.WithError(ex.Message);
            }

            return result.Value;
        }

        public async Task<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>> GetCustomerOrder(long customerId, DateTime startDate, DateTime endDate)
        {
            var command = new
            {
                CustomerId = customerId,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await ServiceCaller.PostDataWithValue<List<Models.Reports.GetSummeryOrderStatusDetailsByDate>>("Order/Order/GetCustomerOrder", command);

            if(result!=null && result.Value!=null)
            {
                return result.Value;
            }

            return null;
        }
    }
}
