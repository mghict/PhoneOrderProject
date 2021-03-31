using System.Collections.Generic;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("AttributeCategoryDetailTbl")]
    public class CustomerAttribute:
        BehsamFramework.Entity.IEntity<int>
    {
        public CustomerAttribute():base()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public bool IsMandetory { get; set; }
        public ICollection<CustomerAttributeValues> ValuesList { get; set; }
    }
}