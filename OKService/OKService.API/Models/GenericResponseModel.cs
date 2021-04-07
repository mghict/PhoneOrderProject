using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKService.API.Models
{
    public class GenericResponseModel<T>
    {
        public T Result { get; set; }
        public string Error { get; set; }
    }
}
