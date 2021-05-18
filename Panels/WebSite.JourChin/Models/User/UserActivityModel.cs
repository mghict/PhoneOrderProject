using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.JourChin.Models.User
{
    public class UserActivityModel
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }

    }

}
