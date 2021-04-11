namespace AccessManagment.Application.PageInfo.Commands
{
    public class DeletePageInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        public int Id { get; set; }
    }
}
