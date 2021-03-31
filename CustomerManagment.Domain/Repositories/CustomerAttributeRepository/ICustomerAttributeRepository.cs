using System.Threading.Tasks;

namespace Data
{
    public interface ICustomerAttributeRepository : Base.IRepository<Models.CustomerAttributeTbl>
    {
        Models.CustomerAttributeTbl GetById(int id);
        Task<Models.CustomerAttributeTbl> GetByIdAsync(int id);

        DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl> GetByAttributeId(int id);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl> GetByAttributeId(int id,bool IsSortedByPriority);
        DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl> GetByAttributeId(int id, bool IsSortedByPriority,byte status);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl>> GetByAttributeIdAsync(int id);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl>> GetByAttributeIdAsync(int id, bool IsSortedByPriority);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerAttributeTbl>> GetByAttributeIdAsync(int id, bool IsSortedByPriority, byte status);
    }
}
