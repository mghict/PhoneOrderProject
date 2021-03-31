using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories
{
    public interface IQueryCustomerValuesRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CustomerAttribute,int>
    {
        
        Task<Entities.CustomerAttribute> GetCustomerAttributeByIdAsync(int attributeId);
    }
}
