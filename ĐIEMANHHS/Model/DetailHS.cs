using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
   public class DetailHS
    {
        public string ID, MaSV, Mamon,Loai,Mark, Hocki;
       
        public DetailHS()
        {

        }
        public DetailHS(string id,string masv,string mamon, string loai, string mark, string hocki)
        {
            ID = id;
            MaSV = masv;
            Mamon = mamon;
            Loai = loai;
            Mark = mark;
            Hocki = hocki;
           
        }
        public string getID()
        {
            return ID;
        }
        public void setID(string value)
        {
            ID = value;
        }
        public string getMaSV()
        {
            return MaSV;
        }
        public void setMaSV(string value)
        {
            MaSV = value;
        }
        public string getMamon()
        {
            return Mamon;
        }
        public void setMamon(string value)
        {
            Mamon = value;
        }

        public string getLoai()
        {
            return Loai;
        }
        public void setLoai(string value)
        {
            Loai = value;
        }

        public string getMark()
        {
            return Mark;
        }
        public void setMark(string value)
        {
            Mark = value;
        }

        public string getHocki()
        {
            return Hocki;
        }
        public void setHocki(string value)
        {
            Hocki = value;
        }

       
    }
}
