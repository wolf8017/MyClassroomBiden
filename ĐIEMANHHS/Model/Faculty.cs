using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Model
{
    public class Faculty
    {
        public string ID, Name;
        public Faculty()
        {

        }
        public Faculty(string id, string name)
        {
            ID = id;
            Name = name;
        }
        public string getID()
        {
            return ID;
        }
        public void setID(string value)
        {
            ID = value;
        }

        public string getName()
        {
            return Name;
        }
        public void setName(string value)
        {
            Name = value;
        }
    }
}
