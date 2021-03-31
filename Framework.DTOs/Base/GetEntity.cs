using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Base
{
    public class GetEntity<T>
    {
        public int RowsCount { get; set; }
        public T Data { get; set; }
    }
}
