using System;
using System.Linq;
using System.Text;
using Dapper;

namespace AccessManagment.Domain.IRepositories.IUserRole
{

    public interface IUserRoleRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Domain.Entities.UserRoleAccessTbl,long>
    {

    }
}
