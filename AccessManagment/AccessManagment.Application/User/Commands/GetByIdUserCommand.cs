namespace AccessManagment.Application.User.Commands
{
    public class GetByIdUserCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserInfoTbl>
    {
        public int Id { get; set; }
    }

}
