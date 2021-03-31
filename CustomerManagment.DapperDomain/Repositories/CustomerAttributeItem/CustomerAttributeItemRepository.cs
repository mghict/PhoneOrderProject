using System.Data;

namespace DataDapper.Repositories.CustomerAttributeItem
{
    public class CustomerAttributeItemRepository : Repository<Models.CustomerAttributeItemTbl, long>, ICustomerAttributeItemRepository
    {
        internal CustomerAttributeItemRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
