using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Application.ApplicationInfo.Commands
{
    public class UpdateApplicationInfoCommand:
        BehsamFramework.Mediator.CommandWithoutReturnValue
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public bool Status { get; set; }
    }
}
