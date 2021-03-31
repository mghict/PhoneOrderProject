using System.Data;

namespace DataDapper.Repositories.CategoryInfo
{
    public class CategoryRepository : Repository<Models.CategoryInfoTbl, double>, ICategoryRepository
    {
        internal CategoryRepository(IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
