using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IPageInfo
{
    public interface IPageInfoRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.PageInfoTbl,int>
    {

    }
}
