using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IPageInfo
{
    public interface IPageInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.PageInfoTbl, int>
    {
        Task<List<Entities.PageInfoTbl>> GetByApplicationId(int appId);

        Task<List<Entities.PageInfoTbl>> GetByParentId(int parentId);
    }
}
