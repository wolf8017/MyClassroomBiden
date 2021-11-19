using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Student_Class_Uni
    {
        public string Id,Name , Lop;
       
        public Student_Class_Uni()
        {

        }
        public Student_Class_Uni(string id, string name, string lop)
        {
            Id = id;
            Name = name;
            Lop = lop;

        }

        public string getId()
        {
            return Id;
        }
        public void setId(string value)
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

        public string getLop()
        {
            return Lop;
        }
        public void seLop(string value)
        {
            Lop = value;
        }

    }
}
