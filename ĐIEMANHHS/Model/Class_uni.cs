using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Model
{
    public class Class_uni
    {
        public string ID, Spec, Faculty;

        public Class_uni()
        {

        }
        public Class_uni(string id, string spec, string faculty)
        {
            ID = id;
            Spec = spec;
            Faculty = faculty;

        }
        public string getID()
        {
            return ID;
        }
        public void setID(string value)
        {
            ID = value;
        }

        public string getSpec()
        {
            return Spec;
        }
        public void setSpec(string value)
        {
            Spec = value;
        }

        public string getFaculty()
        {
            return Faculty;
        }
        public void setFaculty(string value)
        {
            Faculty = value;
        }
    }
}
