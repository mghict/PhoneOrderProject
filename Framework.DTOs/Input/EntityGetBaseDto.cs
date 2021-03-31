using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Input
{
    public class EntityGetBaseDto<T>:Base.DtoInputBase
    {
        public T Id { get; set; }
    }
}
