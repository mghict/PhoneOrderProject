namespace WebSites.Panles.Models.Order
{
    public class CustomerPreOrderUserActiveSummery 
    {
        public int UserId { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public int StatusCount { get; set; }
    }
}
