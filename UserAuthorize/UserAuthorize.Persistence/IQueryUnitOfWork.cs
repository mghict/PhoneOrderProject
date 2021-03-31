using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorize.Persistence
{
    public interface IQueryUnitOfWork:
        BehsamFramework.DapperDomain.Base.IQueryUnitOfWork
    {
        Domain.IRepositories.QueryRepository.IUserQueryRepository UserQueryRepository { get; }

        Domain.IRepositories.QueryRepository.IRoleQueryRepository RoleQueryRepository { get; }
        Domain.IRepositories.QueryRepository.IPageQueryRepository PageQueryRepository { get; }
        Domain.IRepositories.QueryRepository.IApplicationQueryRepository ApplicationQueryRepository { get; }
        Domain.IRepositories.QueryRepository.IUserRoleAccessQueryRepository UserRoleAccessQueryRepository { get; }
        Domain.IRepositories.QueryRepository.IRolePageAccessQueryRepository RolePageAccessQueryRepository { get; }
    }
}
