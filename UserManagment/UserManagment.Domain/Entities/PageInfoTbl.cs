using System.Collections.Generic;

#nullable disable

namespace UserManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("PageInfoTbl")]
    public partial class PageInfoTbl : BehsamFramework.Entity.IEntity<int>
    {
        public PageInfoTbl()
        {
            PageRolePermissionTbls = new HashSet<PageRolePermissionTbl>();
        }

        public int Id { get; set; }
        public string PageName { get; set; }
        public int PageCategoryId { get; set; }
        public string NavbarLink { get; set; }
        public byte IsNavbarPage { get; set; }
        public byte Status { get; set; }

        public virtual PageCategoryTbl PageCategory { get; set; }
        public virtual ICollection<PageRolePermissionTbl> PageRolePermissionTbls { get; set; }
    }
}
