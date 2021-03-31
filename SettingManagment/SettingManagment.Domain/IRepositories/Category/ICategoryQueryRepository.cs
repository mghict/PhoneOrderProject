using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.IRepositories.Category
{
    public interface ICategoryQueryRepository:
        BehsamFramework.DapperDomain.Base.IQueryRepository<Entities.CategoryInfoTbl,float>
    {
        Task<List<BehsamFramework.Models.CategoryShowModel>> GetCategoryByParentAsync(float id);
    }
}
