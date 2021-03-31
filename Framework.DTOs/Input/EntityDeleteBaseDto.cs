using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input
{
    public class EntityDeleteBaseDto<T>:Base.DtoInputBase
    {
        public T id { get; set; }
    }
}
