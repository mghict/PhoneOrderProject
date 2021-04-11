using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace AccessManagment.Persistence.Repositories.PageInfo
{
    public class PageInfoRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.PageInfoTbl, int>,
        Domain.IRepositories.IPageInfo.IPageInfoRepository
    {
        protected internal PageInfoRepository(IDbConnection _db) : base(_db)
        {
        }

        //public override async Task<bool> UpdateAsync(Domain.Entities.PageInfoTbl obj)
        //{
        //    var query = " Update  PageInfotbl set ApplicationId=@ApplicationId, ParentId=@ParentId,PageName=@PageName,Status=@Status,DisplayName=@DisplayName where Id=@Id ";
        //    var param = new
        //    {
        //        @ApplicationId=obj.ApplicationId,
        //        @ParentId=obj.ParentId,
        //        @PageName=obj.PageName,
        //        @Status=obj.Status,
        //        @DisplayName=obj.DisplayName,
        //        @Id=obj.Id
        //    };

        //    var result=await db.ExecuteAsync(query, param);
        //    if(result>=0)
        //    { 
        //        return true; 
        //    }

        //    return false;
        //}
    }
}
