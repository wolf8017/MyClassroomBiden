using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ĐIEMANHHS.Model
{
    public class Class_Subject
    {
        public string Malop, Magv, Mamon, Namhoc;
        public int Hocki,Sobuoi;
        public Class_Subject()
        {

        }
        public Class_Subject(string malop, string magv, string mamon, string namhoc, int hocki, int sobuoi)
        {
            Malop = malop;
            Magv = magv;
            Mamon = mamon;
            Namhoc = namhoc;
            Hocki = hocki;
            Sobuoi = sobuoi;
          
        }

        public string getMalop()
        {
            return Malop;
        }
        public void setMalop(string value)
        {
            Malop = value;
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

        public string getNamhoc()
        {
            return Namhoc;
        }
        public void setNamhoc(string value)
        {
            Namhoc = value;
        }

        public int getHocki()
        {
            return Hocki;
        }
        public void setHocki(int value)
        {
            Hocki = value;
        }

        public int getSobuoi()
        {
            return Sobuoi;
        }
        public void setSobuoi(int value)
        {
            Sobuoi = value;
        }
    }
}
