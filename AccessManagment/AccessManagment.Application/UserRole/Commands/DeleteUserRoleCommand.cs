namespace AccessManagment.Application.UserRole.Commands
{
    public class DeleteUserRoleCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public long Id { get; set; }
    }
}
