using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogManager.Api
{


    public class DataLogFormat
    {
        
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
        public string Data { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
