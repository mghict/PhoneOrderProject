using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories
{
    public interface IAttributeStatusRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.AttributeStatus,int>
    {

    }
}
