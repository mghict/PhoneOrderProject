namespace AccessManagment.Application.RoleInfo.Commands
{
    public class UpdateRoleInfoCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public int ApplicationId { get; set; }
        public bool Status { get; set; }

    }
}
