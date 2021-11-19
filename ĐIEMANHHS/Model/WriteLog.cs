using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class WriteLog
    {
        public string Active, Time;
        public WriteLog()
        {

        }
        public WriteLog(string active, string time)
        {
            Active = active;
            Time = time;
        }
        public string getActive()
        {
            return Active;
        }
        public void setActive(string value)
        {
            Active = value;
        }

        public string getTime()
        {
            return Time;
        }
        public void setTime(string value)
        {
            Time = value;
        }
    }
}
