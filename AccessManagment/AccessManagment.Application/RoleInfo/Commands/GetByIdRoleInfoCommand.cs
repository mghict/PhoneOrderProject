namespace AccessManagment.Application.RoleInfo.Commands
{
    public class GetByIdRoleInfoCommand :
       BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.RoleInfoTbl>
    {
        public int Id { get; set; }

    }
}
