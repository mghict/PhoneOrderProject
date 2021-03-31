﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagment.Application.CustomerInfoFeature.Commands
{
    public class CreateCustomerCommand:
        BehsamFramework.Mediator.CommandWithReturnValue<long>
    {
        public CreateCustomerCommand():base()
        {
            
        }

        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public int CustomerGroupId { get; set; }
        public int RegisterTypeId { get; set; }
        public int Sex { get; set; }
        public int Job { get; set; }
        public int Education { get; set; }
        public byte Status { get; set; }
        public long  DefaultMobile { get; set; }
    }
}
