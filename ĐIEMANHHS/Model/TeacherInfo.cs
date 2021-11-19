using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Model
{
    public class TeacherInfo
    {
        public string ID, Name, Sex, BOD, Address, Phone, Mail, Role;
        public int School;
        public TeacherInfo()
        {

        }
        public TeacherInfo(string id, string name, string sex, string bod, string address, string phone, string mail, string role,int school)
        {
            ID = id;
            Name = name;
            Sex = sex;
            BOD = bod;
            Address = address;
            Phone = phone;
            Mail = mail;
            Role = role;
            School = school;
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

        public string getRole()
        {
            return Role;
        }
        public void setRole(string value)
        {
            Role = value;
        }

        public int getSchool()
        {
            return School;
        }
        public void setSchool(int value)
        {
            School = value;
        }
    }
}
