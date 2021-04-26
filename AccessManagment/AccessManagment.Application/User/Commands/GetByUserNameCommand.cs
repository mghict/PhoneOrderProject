namespace AccessManagment.Application.User.Commands
{
    public class GetByUserNameCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserInfoTbl>
    {
        public long UserName { get; set; }
    }

}
