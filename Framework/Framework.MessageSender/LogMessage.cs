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
        public DateTime CreateDate { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public string Entity { get; set; }
        public string Action { get; set; }
        public long Id { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public T Data
        {
            get
            {
                return data.FromJsonString<T>();
            }
            set
            {
                data = value.ToJsonString().ToString();
            }
        }
    }

    public class LogMessage
    {
        public string Data { get; set; }
        public DateTime CreateDate { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public string Entity { get; set; }
        public string Action { get; set; }
        public long Id { get; set; }
        //-------------------------------
        //===============================
        //-------------------------------
        public int StatusDescription { get; set; }
        public string Description { get; set; }
    }
}
