using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.Models
{
    public class ProductShowModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DisplayName { get; set; }
        public string ProductName { get; set; }
        public float CategotyID { get; set; }
        public string BrandName { get; set; }
        public float UnitPrice { get; set; }
        public int TaxPrice { get; set; }
        public int MeasureType { get; set; }
        public string MeasureTypeStr { get; set; }
        public byte Status { get; set; }
        public byte StatusStr { get; set; }

    }
}
