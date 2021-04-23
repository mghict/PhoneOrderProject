using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerAddressFeature.Commands
{
    public class DefineCustomerAddressAreaCommand:
        MediatR.IRequest
    {
        public long CustomerAddressId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
