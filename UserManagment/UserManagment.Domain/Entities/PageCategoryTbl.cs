using System.Collections.Generic;

#nullable disable

namespace UserManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("PageCategoryTbl")]
    public partial class PageCategoryTbl : BehsamFramework.Entity.IEntity<int>
    {
        public PageCategoryTbl()
        {
            PageInfoTbls = new HashSet<PageInfoTbl>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<PageInfoTbl> PageInfoTbls { get; set; }
    }
}
