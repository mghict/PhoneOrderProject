using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IRepositories
{
    public interface IOrderInfoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.OrderInfo,long>
    {
        Task RegisterOrderAsync(Entities.OrderInfo entity);
    }
}
