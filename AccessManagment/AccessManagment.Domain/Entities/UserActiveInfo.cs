using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.Entities
{
    [Dapper.Contrib.Extensions.Table("UserActiveInfo")]
    public class UserActiveInfo:
        BehsamFramework.Entity.IEntity<long>
    {
        [Dapper.Contrib.Extensions.Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }



}
