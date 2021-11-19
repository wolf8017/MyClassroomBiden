using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Model
{
    public class Account
    {
        public string ID, User, Pass,Email,Role,Phone,Address,Sex,Name,NgaySinh;
        public int Admin, Type,School;
        public Account()
        {

        }
        public Account(string id, string user, string email, string pass, string role,string phone,string address,string sex,string name,string ngaysinh, int admin, int type,int school)
        {
            ID = id;
            User = user;
            Email = email;
            Pass = pass;
            Role = role;
            Phone = phone;
            Address = address;
            Sex = sex;
            Name = name;
            NgaySinh = ngaysinh;
            Type = type;
            Admin = admin;
            School = school;
        }
        public string getNgaySinh()
        {
            return NgaySinh;
        }
        public void setNgaySinh(string value)
        {
            NgaySinh = value;
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
