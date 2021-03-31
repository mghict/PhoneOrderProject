using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results.Province
{
    public class EntityDto:Base.DtoResultBase
    {
        public double Id { get; set; }
        public string ProvinceName { get; set; }

        public IEnumerable<Results.City.EntityDto> City { get; set; }
    }
}
