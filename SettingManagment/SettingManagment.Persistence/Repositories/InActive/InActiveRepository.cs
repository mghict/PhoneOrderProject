using System.Data;
using System.Text;

namespace SettingManagment.Persistence.Repositories.InActive
{
    public class InActiveRepository :
        BehsamFramework.DapperDomain.Repository<Domain.Entities.InActiveTbl, int>,
        Domain.IRepositories.InActive.IInActiveRepository
    {
        protected internal InActiveRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
