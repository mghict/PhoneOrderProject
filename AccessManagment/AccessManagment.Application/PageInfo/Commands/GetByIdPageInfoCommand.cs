namespace AccessManagment.Application.PageInfo.Commands
{
    public class GetByIdPageInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.PageInfoTbl>
    {
        public int Id { get; set; }
    }
}
