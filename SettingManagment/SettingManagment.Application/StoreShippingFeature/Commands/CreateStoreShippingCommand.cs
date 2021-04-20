using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.StoreShippingFeature.Commands
{
    public class CreateStoreShippingCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<int>
    {
        public float StoreID { get; set; }
        public int ShippingPrice { get; set; }
        public bool Status { get; set; }
    }
}
