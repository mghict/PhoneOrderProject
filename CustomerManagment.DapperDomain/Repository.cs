using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDapper
{
    public class Repository<T,TKeyDataType>:Base.Repository<T,TKeyDataType> where T:Models.Base.Entity
    {
        internal Repository(System.Data.IDbConnection idbConnection) : base(idbConnection)
        {
        }
    }
}
