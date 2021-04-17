using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.AreaFeature.Commands
{
    public class CreateAreaInfoCommand :
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public string AreaName { get; set; }
        public int AreaType { get; set; }
        public int ParentID { get; set; }
        public float CenterLatitude { get; set; }
        public float Centerlongitude { get; set; }
        public bool Status { get; set; }
        public int CityId { get; set; }
    }
}
