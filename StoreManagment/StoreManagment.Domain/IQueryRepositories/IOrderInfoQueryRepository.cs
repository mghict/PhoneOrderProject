using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.IQueryRepositories
{
    public interface IOrderInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.OrderInfo, long>
    {

    }
}
