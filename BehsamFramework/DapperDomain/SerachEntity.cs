using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehsamFramework.DapperDomain
{
    public class SerachEntity
    {
        public int PageNo { get; set; }
        public  int PageSize { get; set; }
        public string[] Asc { get; set; }
        public string[] Desc { get; set; }
        public List<Condition> Conditions {get;set; }
    }

    public class Condition
    {
        public string FieldName { get; set; }
        public object FiledValue { get; set; }
        public ConditionType ConditionType { get; set; }
    }

    public  enum ConditionType:int
    {
        Equal = 1,
        GreatThan = 2,
        LessThan = 3,
        Contains = 4,
        Less=5,
        Great=6
    }
}
