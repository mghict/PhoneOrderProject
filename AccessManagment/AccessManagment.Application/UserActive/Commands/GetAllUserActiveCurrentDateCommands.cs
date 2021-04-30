namespace AccessManagment.Application.UserActive.Commands
{
    public class GetAllUserActiveCurrentDateCommands :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserModel>
    {

        public int ApplicationId { get; set; }
        public float StoreId { get; set; }
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Status { get; set; }
    }

}
