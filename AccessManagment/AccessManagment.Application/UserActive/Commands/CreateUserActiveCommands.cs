using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagment.Application.UserActive.Commands
{
    public class CreateUserActiveCommands:
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
