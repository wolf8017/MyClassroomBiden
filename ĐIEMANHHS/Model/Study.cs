using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Study
    {
        public string Buoi, Batdau, Ketthuc, Ngay,Magv,Mamon;
       
        public Study()
        {

        }
        public Study(string buoi, string batdau, string kethuc, string ngay, string magv, string mamon)
        {
            Buoi = buoi;
            Batdau = batdau;
            Ketthuc = kethuc;
            Ngay = ngay;
            Magv = magv;
            Mamon = mamon;

        }

        public string getBuoi()
        {
            return Buoi;
        }
        public void setBuoi(string value)
        {
            Buoi = value;
        }
        public string getBatdau()
        {
            return Batdau;
        }
        public void setBatdau(string value)
        {
            Batdau = value;
        }

        public string getKetthuc()
        {
            return Ketthuc;
        }
        public void setKetthuc(string value)
        {
            Ketthuc = value;
        }

        public string getNgay()
        {
            return Ngay;
        }
        public void setNgay(string value)
        {
            Ngay = value;
        }

        public string getMagv()
        {
            return Magv;
        }
        public void setMagv(string value)
        {
            Magv = value;
        }

        public string getMamon()
        {
            return Mamon;
        }
        public void setMamon(string value)
        {
            Mamon = value;
        }
    }
}
