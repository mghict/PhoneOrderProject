using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.PageInfo.Commands
{
    public class CreatePageInfoCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public string PageName { get; set; }
        public string DisplayName { get; set; }
        public int ApplicationId { get; set; }
        public int ParentId { get; set; }
        public bool Status { get; set; }
    }
}
