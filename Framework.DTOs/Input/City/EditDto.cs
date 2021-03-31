using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input.City
{
    public class EditDto:DTOs.Base.DtoInputBase
    {
        public int Id { get; set; }
        public double CityId { get; set; }
        public string CityName { get; set; }
        public double ProvinceId { get; set; }
    }
}
