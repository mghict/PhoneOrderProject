using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.TimeSheet
{
    public interface ITimeSheetRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.TimeSheet,int>
    {
    }
}
