using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Domain.Entities
{
    public class UserModel
    {
        public long RowCount { get; set; }
        public List<Domain.Entities.UserInfo> Users { get; set; }
    }
}
