﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.Entities
{
    public class RolePagesAccess
    {
        public int PageId { get; set; }
        public string DisplayName { get; set; }
        public int ParentId { get; set; }
        public int PageAccessId { get; set; }
        public bool IsAccess { get; set; }
        public int ApplicationId { get; set; }
        public int RoleId { get; set; }
    }
}
