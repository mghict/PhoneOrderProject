﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.IRepositories.UsersRolesInfo
{
    public interface IUsersRolesRepository:
        BehsamFramework.DapperDomain.Base.IRepository<Entities.UserRoleTbl,int>
    {
    }
}
