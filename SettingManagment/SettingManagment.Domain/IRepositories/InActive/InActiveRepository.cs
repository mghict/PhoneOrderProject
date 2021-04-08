using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.InActive
{
    public interface IInActiveRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.InActiveTbl,int>
    {
    }
}
