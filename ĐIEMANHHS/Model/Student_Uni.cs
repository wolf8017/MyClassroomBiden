using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Student_Uni
    {

        public string ID, Name, Class_ID, BOD, Sex,Address, Phone, Mail;
        public int School;
        public Student_Uni()
        {

        }
        public Student_Uni(string id,string name, string classid, string bod,string sex, string address, string phone, string mail)
        {
            ID = id;
            Name = name;
            Sex = sex;
            BOD = bod;
            Address = address;
            Phone = phone;
            Mail = mail;
            Class_ID = classid;
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

        public string getSex()
        {
            return Sex;
        }
        public void setSex(string value)
        {
            Sex = value;
        }

        public string getBOD()
        {
            return BOD;
        }
        public void setBOD(string value)
        {
            BOD = value;
        }

        public string getAddress()
        {
            return Address;
        }
        public void setAddress(string value)
        {
            Address = value;
        }

        public string getPhone()
        {
            return Phone;
        }
        public void setPhone(string value)
        {
            Phone = value;
        }

        public string getMail()
        {
            return Mail;
        }
        public void setMail(string value)
        {
            Mail = value;
        }

        public string getClass()
        {
            return Class_ID;
        }
        public void setClass(string value)
        {
            Class_ID = value;
        }
    }
}
