using System.Threading.Tasks;

namespace StoreManagment.Domain.IRepositories
{
    public interface IOrderItemsRepository :
        BehsamFramework.DapperDomain.Base.IRepository<Entities.OrderItems, long>
    {
        Task<bool> ChangeOrderItemStatusAsync(long id, int status);
    }
}
