﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Base
{
    public class GetEnumerableEntity<T>
    {
        public int RowsCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
