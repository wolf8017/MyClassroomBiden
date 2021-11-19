using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Roll
    {
        public string Masv, Name, Lop, Buoi,Gio,Ngay,Status;
       
        public Roll()
        {

        }
        public Roll(string masv, string name, string lop, string buoi, string gio, string ngay,string status)
        {
            Masv = masv;
            Name = name;
            Lop = lop;
            Buoi = buoi;
            Gio = gio;
            Ngay = ngay;
            Status = status;
        }

        public string getMasv()
        {
            return Masv;
        }
        public void setMasv(string value)
        {
            Masv = value;
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
        public void setLop(string value)
        {
            Lop = value;
        }

        public string getBuoi()
        {
            return Buoi;
        }
        public void setBuoi(string value)
        {
            Buoi = value;
        }

        public string getGio()
        {
            return Gio;
        }
        public void setGio(string value)
        {
            Gio = value;
        }

        public string getNgay()
        {
            return Ngay;
        }
        public void setNgay(string value)
        {
            Ngay = value;
        }

        public string getStatus()
        {
            return Status;
        }
        public void setStatus(string value)
        {
            Status = value;
        }
    }
}
