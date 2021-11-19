using Biden.Data;
using ĐIEMANHHS.Model;
using ĐIEMANHHS.ShareData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class THPT : Form
    {
        public THPT()
        {
            InitializeComponent();
        }

        private void THPT_Load(object sender, EventArgs e)
        {
            loadClass_HS();
        }
        void loadClass_HS()
        {
            DataHS.Rows.Clear();
            string query = "select * from class_hs order by CLHS_ID ASC";
            List<ClassTHPT> list = DataHelper.FindTHPT(query);
            foreach (ClassTHPT item in list)
            {
                DataHS.Rows.Add(item.getID());
            }
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtclass.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.InsertTHPT(chiase.acc.getUser(), txtclass.Text.Trim())=="1")
            {
                Alert("Thêm lớp thành công", showBiden.enmType.Success);
                loadClass_HS();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Warning);
                return;
            }
        }

     

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
