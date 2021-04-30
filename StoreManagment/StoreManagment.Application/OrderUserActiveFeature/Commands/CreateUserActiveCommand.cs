using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class CreateUserActiveCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        //public long Id { get; set; }
        public int UserId { get; set; }
        public long OrderCode { get; set; }
        public int Status { get; set; }
        //public DateTime CreateDate { get; set; }
    }
}
