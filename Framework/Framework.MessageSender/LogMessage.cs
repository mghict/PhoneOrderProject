using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.MessageSender
{
    public class LogMessage<T>
    {
        private string data;
        public string IP { get; set; }
        public string Entity { get; set; }
        public string Action { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public T Data
        {
            get
            {
                return data.FromJsonString<T>();
            }
            set
            {
                data = value.ToJsonString();
            }
        }
    }
}
