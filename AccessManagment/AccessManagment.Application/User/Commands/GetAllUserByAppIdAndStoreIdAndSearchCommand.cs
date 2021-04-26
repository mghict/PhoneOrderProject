namespace AccessManagment.Application.User.Commands
{
    public class GetAllUserByAppIdAndStoreIdAndSearchCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.UserModel>
    {
        public int ApplicationId { get; set; }
        public float StoreId { get; set; }
        public string SearchKey { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

}
