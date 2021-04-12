namespace AccessManagment.Application.RoleInfo.Commands
{
    public class DeleteRoleInfoCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }

    }
}
