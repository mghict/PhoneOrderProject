using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input
{
    public class EntityGetBasePagination<T>:EntityGetBaseDto<T>
    {
        public int PageNO { get; set; }
        public int PageSize { get; set; }
    }
}
