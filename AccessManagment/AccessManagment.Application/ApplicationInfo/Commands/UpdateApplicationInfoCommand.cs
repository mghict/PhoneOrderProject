using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.ApplicationInfo.Commands
{
    public class UpdateApplicationInfoCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.ApplicationInfoTbl>
    {
        public int Id { get; set; }
        public string ApplicationName { get; set; }
        public bool Status { get; set; }
    }
}
