using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeCategoryTbl")]
    public class AttributesCategory:BehsamFramework.Entity.IEntity<int>
    {
        public AttributesCategory():base()
        {
                
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public bool Status { get; set; }

    }
}
