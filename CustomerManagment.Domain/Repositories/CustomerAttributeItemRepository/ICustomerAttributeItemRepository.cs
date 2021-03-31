using System.Threading.Tasks;

namespace Data
{
    public interface ICustomerAttributeItemRepository : Base.IRepository<Models.CustomerAttributeItemTbl>
    {
        Models.CustomerAttributeItemTbl GetById(long id);
        Task<Models.CustomerAttributeItemTbl> GetByIdAsync(long id);

        DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeItemTbl> GetByCustomer(long custId);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeItemTbl>> GetByCustomerAsync(long custId);

        DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeItemTbl> GetByCustomerAndAttribute(long custId,int attrId);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeItemTbl>> GetByCustomerAndAttributeAsync(long custId, int attrId);
    }
}
