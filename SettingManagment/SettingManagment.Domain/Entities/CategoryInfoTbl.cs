using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("CategoryInfoTbl")]
    public class CategoryInfoTbl:BehsamFramework.Entity.IEntity<float>
    {
        [Dapper.Contrib.Extensions.Key]
        public float Id { get; set; }
        public string CategoryName { get; set; }
        public float ParentId { get; set; }
        public string ImageUrl { get; set; }
        public int Priority { get; set; }
        public byte Status { get; set; }
    }
}
