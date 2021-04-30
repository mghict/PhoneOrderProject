namespace AccessManagment.Application.UserActive.Commands
{
    public class GetByUserIdCurrentDateCommands :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserActiveInfo>
    {

        public int UserId { get; set; }
    }

}
