using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.Province
{
    public class AddDto:Base.DtoInputBase
    {
        public double Id { get; set; }
        public string ProvinceName { get; set; }
    }
}
