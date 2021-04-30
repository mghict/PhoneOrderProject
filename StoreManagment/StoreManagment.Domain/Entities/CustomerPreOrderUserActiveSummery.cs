namespace StoreManagment.Domain.Entities
{
    public class CustomerPreOrderUserActiveSummery 
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public int StatusCount { get; set; }
    }
}
