using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUser
{
    public interface IUserQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserInfoTbl, int>
    {
        Task<Domain.Entities.UserModel> GetAllBySearchAsync(string SearchKey = "", int PageNumber = 0, int PageSize = 20);
        Task<Domain.Entities.UserModel> GetAllByAppIdAndStoreIdAndSearchAsync(int appId,float storeId=0,string SearchKey = "", int PageNumber = 0, int PageSize = 20);
        Task<Domain.Entities.UserInfoTbl> GetUserByUserName(long userName);


    }
}
