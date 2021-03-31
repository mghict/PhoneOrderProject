using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class CustomerValuesCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<Domain.Entities.CustomerAttribute>
    {
        public CustomerValuesCommand():base()
        {
            
        }
        public int Id { get; set; }
    }
}
