using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.Category
{
    public class EntityDto:Base.DtoResultBase
    {
        public double Id { get; set; }
        public string CategoryName { get; set; }
        public double? ParentId { get; set; }
        public string ImageUrl { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }

        public IEnumerable<Product.EntityDto> Products { get; set; }
    }
}
