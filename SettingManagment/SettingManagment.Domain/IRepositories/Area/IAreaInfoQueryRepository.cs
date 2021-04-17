using System.Collections.Generic;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Area
{
    public interface IAreaInfoQueryRepository :
        BehsamFramework.DapperDomain.Base.IQueryRepository<Domain.Entities.AreaInfoTbl, int>
    {
        Task<List<Domain.Entities.AreaInfoTbl>> GetByCityId(int cityId, int areaType);

        Task<List<Domain.Entities.AttributeStatus>> GetAreaType();

        Task<List<Domain.Entities.AreaInfoTbl>> GetByParentId(int parentId, int areaType);

        Task<Domain.Entities.AreaModel> GetAllSearch(string searchKey="", int pageNumber=0,int pageSize=20);
    }
}
