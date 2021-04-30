using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUserActive
{
    public interface IUserActiveQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserActiveInfo, long>
    {
        Task<Domain.Entities.UserModel> GetUserActiveCurrentDateAsync(int appId, float storeId = 0, string SearchKey = "", int PageNumber = 0, int PageSize = 20,int Status=100);

        Task<Entities.UserActiveInfo> GetByUserIdCurrentDateAsync(int userId);
    }
}
