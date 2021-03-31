using System.Collections.Generic;

#nullable disable

namespace CustomerManagment.DapperDomain.Models.Entities
{
    [Dapper.Contrib.Extensions.Table("PageInfoTbl")]
    public partial class PageInfoTbl : Models.Base.Entity
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
