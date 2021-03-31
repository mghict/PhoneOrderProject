using System.Threading.Tasks;

namespace Data
{
    public interface ICustomerPhoneRepository : Base.IRepository<Models.CustomerPhoneTbl>
    {
        Models.CustomerPhoneTbl GetById(long id);
        Task<Models.CustomerPhoneTbl> GetByIdAsync(long id);
        DTOs.Base.GetEnumerableEntity<Models.CustomerPhoneTbl> GetByCustomerId(long id);
        Task<DTOs.Base.GetEnumerableEntity<Models.CustomerPhoneTbl>> GetByCustomerIdAsync(long id);

        Models.CustomerPhoneTbl GetByPhone(long phoneValue);
        Task<Models.CustomerPhoneTbl> GetByPhoneAsync(long phoneValue);
    }
}
