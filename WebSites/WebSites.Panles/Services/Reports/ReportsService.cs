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

    }
}
