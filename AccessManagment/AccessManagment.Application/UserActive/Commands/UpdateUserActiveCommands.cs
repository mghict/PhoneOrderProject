using System;

namespace AccessManagment.Application.UserActive.Commands
{
    public class UpdateUserActiveCommands :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
