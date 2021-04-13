using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUser
{
    public interface IUserQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.UserInfoTbl, int>
    {
        Task<Domain.Entities.UserModel> GetAllBySearchAsync(string SearchKey = "", int PageNumber = 0, int PageSize = 20);
    }
}
