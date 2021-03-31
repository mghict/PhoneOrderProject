using System.Linq;
using System.Threading.Tasks;

namespace WebSites.Panles.Models.Order
{
    public class CachedOrderItem
    {
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public string ProductName { get; set; }
    }
}
