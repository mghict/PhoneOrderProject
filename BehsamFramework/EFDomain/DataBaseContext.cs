using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehsamFramework.EFDomain.Base;
using Microsoft.EntityFrameworkCore;

namespace BehsamFramework.EFDomain
{
    public class DataBaseContext:DbContext,IDataBaseContext
    {
    }
}
