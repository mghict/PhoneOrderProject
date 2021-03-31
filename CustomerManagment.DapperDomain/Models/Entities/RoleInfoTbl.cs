using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("RoleInfoTbl")]
    public partial class RoleInfoTbl : Models.Base.Entity
    {
        public RoleInfoTbl()
        {
            PageRolePermissionTbls = new HashSet<PageRolePermissionTbl>();
            UserRoleTbls = new HashSet<UserRoleTbl>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public int? ParentId { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<PageRolePermissionTbl> PageRolePermissionTbls { get; set; }
        public virtual ICollection<UserRoleTbl> UserRoleTbls { get; set; }
    }
}
