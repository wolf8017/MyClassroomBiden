using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
   public class ClassTHPT
    {
        public string ID;

        public ClassTHPT()
        {

        }
        public ClassTHPT(string id)
        {
            ID = id;
        }
        public string getID()
        {
            return ID;
        }
        public void setID(string value)
        {
            ID = value;
        }
    }
}
