using Biden.Data;
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
    public partial class UpdateTeacher : Form
    {
        public UpdateTeacher()
        {
            InitializeComponent();
        }

        private void UpdateTeacher_Load(object sender, EventArgs e)
        {
            txtrole.Text = LayTeacher.info.getRole();
            if(LayTeacher.info.getSchool()==0)
            {
                rdNo.Checked = true;
            }
            else if(LayTeacher.info.getSchool() == 1)
            {
                rdYes.Checked = true;
            }
            if(chiase.acc.getAdmin()==0)
            {
                cbadmin.SelectedIndex = cbadmin.FindStringExact("Không");
            }
            else if(chiase.acc.getAdmin() == 1)
            {
                cbadmin.SelectedIndex = cbadmin.FindStringExact("Admin");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string user = chiase.acc.getUser();
            string id= LayTeacher.info.getID();
            string role = txtrole.Text;
            int in_skl = rdYes.Checked ? 1 : 0;
            if(DataHelper.updateGiaovien(user,id,role,in_skl)=="1")
            {
                MessageBox.Show("Cập nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Cập nhập thất bại!", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
