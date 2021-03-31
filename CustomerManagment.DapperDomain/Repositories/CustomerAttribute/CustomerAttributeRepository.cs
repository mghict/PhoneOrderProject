using System.Data;

namespace DataDapper.Repositories.CustomerAttribute
{
    public class CustomerAttributeRepository : Repository<Models.CustomerAttributeTbl, long>, ICustomerAttributeRepository
    {
        internal CustomerAttributeRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
