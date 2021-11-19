using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Subject
    {
        public string Admin, Id, Name;

        public Subject()
        {

        }
        public Subject(string admin, string id, string name)
        {
            Id = id;
            Name = name;
            Admin = admin;

        }
        public string getID()
        {
            return Id;
        }
        public void setID(string value)
        {
            Id = value;
        }

        public string getName()
        {
            return Name;
        }
        public void setName(string value)
        {
            Name = value;
        }

        public string getAdmin()
        {
            return Admin;
        }
        public void setAdmin(string value)
        {
            Admin = value;
        }
    }
}
