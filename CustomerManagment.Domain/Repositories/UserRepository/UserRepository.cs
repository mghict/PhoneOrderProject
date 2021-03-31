using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class UserInfoRepository : Repository<Models.UserInfoTbl>, IUserInfoRepository
    {
        internal UserInfoRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public UserInfoTbl GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            var result =
                DbSet
                .Where(current => current.UserName.ToLower() == username.ToLower())
                .FirstOrDefault();

            return result;
        }

        public Task<UserInfoTbl> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            var result =
                DbSet
                .Where(current => current.UserName.ToLower() == username.ToLower())
                .FirstOrDefaultAsync();

            return result;
        }

        public List<UserInfoTbl> GetActive()
        {
            var result =
                DbSet
                .Where(current => current.Status == 2)
                .ToList()
                ;

            return result;
        }

        public Task<List<UserInfoTbl>> GetActiveAsync()
        {
            var result =
                DbSet
                .Where(current => current.Status == 2)
                .ToListAsync()
                ;

            return result;
        }
    }
}
