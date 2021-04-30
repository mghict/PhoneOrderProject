using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.IRepositories.IUserActive
{
    public interface IUserActiveRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.UserActiveInfo,long>
    {
        Task<bool> UpdateStatusAsync(int userId, int status, DateTime createDate);
    }
}
