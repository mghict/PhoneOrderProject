using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("StoreTimeSheetTbl")]
    public class TimeSheet:
        BehsamFramework.Entity.IEntity<int>
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }

        [Description("ToTime")]
        [Column(name: "ToTime")]
        public TimeSpan EndTime { get; set; }
        public int StepTime { get; set; }
    }
}
