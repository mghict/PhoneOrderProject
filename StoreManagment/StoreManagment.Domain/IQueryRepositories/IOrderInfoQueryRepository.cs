﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IQueryRepositories
{
    public interface IOrderInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.OrderInfo, long>
    {
        Task<List<Entities.GetSummeryOrderByDate>> getSummeryOrderByDates(DateTime startDate, DateTime endDate);
        Task<List<Entities.GetSummeryOrderStatusByDate>> getSummeryOrderStatusByDate(float storeId,DateTime startDate, DateTime endDate);
        Task<List<Entities.GetSummeryOrderStatusDetailsByDate>> getSummeryOrderStatusDetailsByDate(float storeId, DateTime startDate, DateTime endDate,int status);
        Task<List<Entities.GetOrderDetailsByUserId>> getOrderDetailsByUserId(DateTime startDate, DateTime endDate, float storeId = 0.0f, int userId = 0);
        Task<Entities.GetOrderInfoWithItems> getOrderInfoWithItems(long OrderCode);
        Task<List<Entities.GetSummeryOrdersByDateAndStore>> getSummeryOrdersByDateAndStore(DateTime orderDate,float storeId);
        Task<List<Entities.GetDetailsOrdersByDateAndStore>> getDetailsOrdersByDateAndStore(DateTime orderDate,float storeId ,string orderTime);
        Task<List<Entities.OrderByStatusItem>> getOrderByStatusItem(int status,int itemStatus,int userId=0);
        Task<List<Entities.GetSummeryOrderStatusDetailsByDate>> getCustomerOrder(long customerId, DateTime startDate, DateTime endDate);
    }
}
