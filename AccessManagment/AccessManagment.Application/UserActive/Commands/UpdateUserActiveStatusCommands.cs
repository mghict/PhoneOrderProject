using System;

namespace AccessManagment.Application.UserActive.Commands
{
    public class UpdateUserActiveStatusCommands :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {

        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
