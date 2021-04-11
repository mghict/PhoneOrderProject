namespace AccessManagment.Application.PageInfo.Commands
{
    public class UpdatePageInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string DisplayName { get; set; }
        public int ApplicationId { get; set; }
        public int ParentId { get; set; }
        public bool Status { get; set; }
    }
}
