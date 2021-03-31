using BehsamFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Domain.IRepository.CustomerInfo
{
    public interface ICustomerQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerInfoTbl,long>
    {
        Task<CustomerInfoListModel> GetAllByPageingAndSearch(int pageNumber, int pageSize, string search);
        Task<CustomerInfoModel> GetCustomerBySearch(string search);
        Task<Entities.CustomerInfoTbl> GetCustomerByDefaultMobileAsync(long mobileNumber);
    }
}
