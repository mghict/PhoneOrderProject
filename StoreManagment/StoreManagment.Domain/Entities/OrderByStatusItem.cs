﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagment.Domain.Entities
{
    public class OrderByStatusItem
    {
        public long ID { get; set; }
        public long OrderCode { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal StoreID { get; set; }
    }
}
