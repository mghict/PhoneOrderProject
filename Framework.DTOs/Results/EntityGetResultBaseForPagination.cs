using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Results
{
    public class EntityGetResultBaseForPagination<T>
    {
        public int RecordCount { get; set; }
        public T Data { get; set; }

    }
}
