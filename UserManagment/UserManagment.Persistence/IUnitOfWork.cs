using BehsamFramework.DapperDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.IRepositories.ApplicationInfo;

namespace UserManagment.Persistence
{
    public interface IUnitOfWork:
        BehsamFramework.DapperDomain.Base.IUnitOfWork
    {
        Domain.IRepositories.ApplicationInfo.IApplicationInfoRepository ApplicationInfoRepository { get; }
    }

    public class UnitOfWork :
        BehsamFramework.DapperDomain.UnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(Options options) : base(options)
        {
        }

        private IApplicationInfoRepository _applicationInfoRepository;
        public IApplicationInfoRepository ApplicationInfoRepository =>
            _applicationInfoRepository = _applicationInfoRepository ?? new Repositories.ApplicationInfo.ApplicationInfoRepository(IDbConnection);
    }
}
