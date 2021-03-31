using SettingManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagment.Application.CustomerValuesFeature.Commands
{
    public class AttributeStatusCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<List<AttributeStatus>>
    {
        public AttributeStatusCommand():base()
        {
            
        }
    }
}
