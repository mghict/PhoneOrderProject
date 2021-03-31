using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Persistence.Repositories.UsersRolesInfo
{
    public class UsersRolesInfoRepository:
        BehsamFramework.DapperDomain.Repository<Domain.Entities.UserRoleTbl,int>,
        Domain.IRepositories.UsersRolesInfo.IUsersRolesRepository
    {
        protected internal UsersRolesInfoRepository(IDbConnection _db) : base(_db)
        {
        }
    }
}
