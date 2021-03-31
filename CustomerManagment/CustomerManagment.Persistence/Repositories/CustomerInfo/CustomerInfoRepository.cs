using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Persistence.Repositories.CustomerInfo
{
    public class CustomerInfoRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.CustomerInfoTbl,long>,
        Domain.IRepository.CustomerInfo.ICustomerRepository
    {
        protected internal CustomerInfoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
