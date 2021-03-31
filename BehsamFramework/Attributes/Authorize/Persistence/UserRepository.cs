using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.Entity;
using Dapper.Contrib.Extensions;

namespace BehsamFramework.Attributes.Authorize.Persistence
{
    public class UserRepository
    {
        protected IDbConnection db { get; }
        public UserRepository(IDbConnection _db)
        {
            db = _db;
        }

        public bool IsValidAccess(int userid,string controlName, string actioName)
        {
            return true;
        }

        public async Task<bool> IsValidAccessAsync(int userid, string controlName, string actioName)
        {
            return true;
        }

        public async Task<UserInfoTbl> GetUserAsync(int userId)
        {
            return await db.GetAsync<UserInfoTbl>(userId);
        }
    }
}
