using System;

namespace SettingManagment.Domain.Entities
{
    public class StoreInActiveTbl :
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public float StoreId { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToTime { get; set; }
        public bool Status { get; set; }
    }
}
