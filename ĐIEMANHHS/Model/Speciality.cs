using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Model
{
    public class Speciality
    {
        public string ID, Name, Faculty;

        public Speciality()
        {

        }
        public Speciality(string id, string name, string faculty)
        {
            ID = id;
            Name = name;
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

        public string getName()
        {
            return Name;
        }
        public void setName(string value)
        {
            Name = value;
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
