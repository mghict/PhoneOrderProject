using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class ProductReserveModel
    {
        public int RowCount { get; set; }
        public List<ProductReserveItemsModel> Items { get; set; }
    }
    public class ProductReserveItemsModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public float CategoryId { get; set; }

    }
}
