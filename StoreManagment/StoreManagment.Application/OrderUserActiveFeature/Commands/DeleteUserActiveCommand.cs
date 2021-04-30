namespace StoreManagment.Application.OrderUserActiveFeature.Commands
{
    public class DeleteUserActiveCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<bool>
    {
        //public long Id { get; set; }

        public int UserId { get; set; }
        public long OrderCode { get; set; }

        //public int Status { get; set; }

        //public DateTime CreateDate { get; set; }
    }
}
