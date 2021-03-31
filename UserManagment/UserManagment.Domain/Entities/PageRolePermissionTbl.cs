#nullable disable

namespace UserManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("PageRolePermissionTbl")]
    public partial class PageRolePermissionTbl : BehsamFramework.Entity.IEntity<int>
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PageId { get; set; }
        public int PermissionId { get; set; }
        public byte Status { get; set; }

        public virtual PageInfoTbl Page { get; set; }
        public virtual RoleInfoTbl Role { get; set; }
    }
}
