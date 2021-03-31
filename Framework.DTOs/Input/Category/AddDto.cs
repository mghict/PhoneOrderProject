using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.Category
{
    public class AddDto:Base.DtoInputBase
    {
        public string CategoryName { get; set; }
        public double? ParentId { get; set; }
        public string ImageUrl { get; set; }
        public short Priority { get; set; }
        public byte Status { get; set; }
    }
}
