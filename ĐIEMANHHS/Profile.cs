using Biden.Data;
using Biden.Model;
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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }
        private Account acc = new Account();
        //private void btndmk_Click(object sender, EventArgs e)
        //{
        //    DoiMatKhau dmk = new DoiMatKhau();
        //    dmk.ShowDialog();
        //}
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            load();
           
        }
        void load()
        {
            txtuser.Text = chiase.acc.getUser();
            txtU.Text = chiase.acc.getUser();
            acc = DataHelper.FindProfile(chiase.acc.getUser());
           
            date.Text = acc.getNgaySinh();
            txtemail.Text = acc.getEmail();
            txtname.Text = acc.getName();
            txtaddress.Text = acc.getAddress();
            txtrole.Text = acc.getRole();
            txtsdt.Text = acc.getPhone();
            if (acc.getSex() == "Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(txtname.Text==""||txtsdt.Text==""||txtaddress.Text=="")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            acc.setUser(txtuser.Text);
            acc.setName(txtname.Text);
            acc.setEmail(txtemail.Text);
            acc.setPhone(txtsdt.Text);
            acc.setSex(rdNam.Checked?"Nam":"Nữ");
            acc.setNgaySinh(date.Text);
            acc.setAddress(txtaddress.Text);
            if(DataHelper.UpdateProfile(acc)=="1")
            {
                Alert("Đã cập nhập thông tin", showBiden.enmType.Success);
                load();
            }
            else
            {
                Alert("Cập nhập thất bại", showBiden.enmType.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtpasscu.Text==""|| txtpass.Text.Trim() == "" || txtpass1.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (txtpass.Text.Trim() != txtpass1.Text.Trim())
            {
                Alert("Mật khẩu không khớp nhau!", showBiden.enmType.Warning);
                return;
            }
            else
            {
                Account acc = DataHelper.CheckPass(txtuser.Text.Trim(), txtpasscu.Text.Trim());
                if (acc != null)
                {
                    if (DataHelper.changePass(txtU.Text.Trim(), txtpass.Text.Trim(), txtpass1.Text.Trim())=="1")
                    {
                        Alert("Đổi mật khẩu thành công", showBiden.enmType.Success);
                    }
                    else
                    {
                        Alert("Đổi thất mật khẩu thất bại", showBiden.enmType.Error);
                        return;
                    }
                }
                else
                {
                    Alert("Mật khẩu cũ không chính xác", showBiden.enmType.Error);
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
