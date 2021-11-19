using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class GetData
    {
        public string ID, User, Pass, Email, Role;
        public int Admin, Type, School;
        public GetData()
        {

        }
        public GetData(string id, string user, string email, string pass, string role, int admin, int type, int school)
        {
            ID = id;
            User = user;
            Email = email;
            Pass = pass;
            Role = role;
            Type = type;
            Admin = admin;
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

        public string getUser()
        {
            return User;
        }
        public void setUser(string value)
        {
            User = value;
        }

        public string getPass()
        {
            return Pass;
        }
        public void setPass(string value)
        {
            Pass = value;
        }

        public string getRole()
        {
            return Role;
        }
        public void setRole(string value)
        {
            Role = value;
        }

        public int getAdmin()
        {
            return Admin;
        }
        public void setAdmin(int value)
        {
            Admin = value;
        }

        public string getEmail()
        {
            return Email;
        }
        public void setEmail(string value)
        {
            Email = value;
        }

        public int getType()
        {
            return Type;
        }
        public void setType(int value)
        {
            Type = value;
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
