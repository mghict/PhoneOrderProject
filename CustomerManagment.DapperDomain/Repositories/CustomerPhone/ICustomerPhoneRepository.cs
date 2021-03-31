using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper.Repositories.CustomerPhone
{
    public interface ICustomerPhoneRepository:Base.IRepository<Models.CustomerPhoneTbl,long>
    {
        IEnumerable<Models.CustomerPhoneTbl> GetPhone(long phone);
        Task<IEnumerable<Models.CustomerPhoneTbl>> GetPhoneAsync(long phone);

        IEnumerable<Models.CustomerPhoneTbl> GetPhoneByType(long id,int type);
        Task<IEnumerable<Models.CustomerPhoneTbl>> GetPhoneByTypeAsync(long id,int type);

        Models.CustomerInfoTbl GetCustomer(long phone);
        Task<Models.CustomerInfoTbl> GetCustomerAsync(long phone);
    }
}
