using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.CustomerInfo
{
    public interface ICustomerRepository:Base.IRepository<Models.CustomerInfoTbl,long>
    {
        Models.CustomerInfoTbl GetByCustomerCode(string customerCode);
        Task<Models.CustomerInfoTbl> GetByCustomerCodeAsync(string customerCode);

        long GetMaxId();
        Task<long> GetMaxIdAsync();
    }
}
