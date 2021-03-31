using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Persistence.Repositories.AttributeStatus
{
    public class AttributeStatusRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.AttributeStatus,int>,
        Domain.IRepositories.IAttributeStatusRepository
    {
        protected internal AttributeStatusRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
