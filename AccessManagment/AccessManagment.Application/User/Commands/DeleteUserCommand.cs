namespace AccessManagment.Application.User.Commands
{
    public class DeleteUserCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
    }

}
