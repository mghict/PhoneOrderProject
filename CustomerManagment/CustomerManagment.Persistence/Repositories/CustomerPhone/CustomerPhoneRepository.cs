using System.Data;

namespace CustomerManagment.Persistence.Repositories.CustomerPhone
{
    public class CustomerPhoneRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.CustomerPhoneTbl, long>,
        Domain.IRepository.CustomerPhone.ICustomerPhoneRepository
    {
        protected internal CustomerPhoneRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}