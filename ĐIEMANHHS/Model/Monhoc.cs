using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Monhoc
    {
        public string User, Mamon, Name;

        public Monhoc()
        {

        }
        public Monhoc(string user, string mamon, string name)
        {
            User = user;
            Mamon = mamon;
            Name = name;

        }
        public string getUser()
        {
            return User;
        }
        public void setUser(string value)
        {
            User = value;
        }

        public string getMamon()
        {
            return Mamon;
        }
        public void setMamon(string value)
        {
            Mamon = value;
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
