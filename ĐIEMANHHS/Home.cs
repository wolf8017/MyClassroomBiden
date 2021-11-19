using Biden.Data;
using Biden.Model;
using ĐIEMANHHS.ShareData;
using MySql.Data.MySqlClient;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private Account acc = new Account();
        private void Home_Load(object sender, EventArgs e)
        {
            acc = DataHelper.FindProfile(chiase.acc.getUser());
            lbuser.Text = "User: " + acc.getUser();
            lbrole.Text = "Role: " + acc.getRole();
            string type = getType();
            string ad = getAdmin();
            if (type == "2" && ad != "1")
            {
                btnpercent.Visible = true;
                btnadmin.Visible = false;
            }
            else if (type == "1" && ad != "1")
            {
                btnpercent.Visible = false;
                btnadmin.Visible = false;
            }
            else
            {
                btnpercent.Visible = false;
                btnroll.Visible = false;
                btnmark.Visible = false;
                btntotal.Visible = false;
            }
        }
        private string getAdmin()
        {
            string id = "";
            string query = "select* from teacher_login where Tchr_ID='" + chiase.acc.getUser() + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                data.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    id = item["isAdmin"].ToString();
                }
                connec.Close();

                return id;
            }
        }
        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (sidebar.Width == 193)
            {
                sidebar.Visible = false;
                sidebar.Width = 45;
                lbrole.Visible = false;
                lbuser.Visible = false;
                logo.Visible = false;
                PanelAni.ShowSync(sidebar);

            }
            else
            {
                sidebar.Visible = false;
                sidebar.Width = 193;
                lbrole.Visible = true;
                lbuser.Visible = true;
                logo.Visible = true;
                PanelAni.ShowSync(sidebar);

            }
        }

        private void btnroll_Click(object sender, EventArgs e)
        {

            panelMain.Controls.Clear();
            RollCall p = new RollCall();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmark_Click(object sender, EventArgs e)
        {
            string type = getType();
            if (type == "1")
            {
                panelMain.Controls.Clear();
                DetailMarkHS p = new DetailMarkHS();
                p.TopLevel = false;
                panelMain.Controls.Add(p);
                p.Dock = DockStyle.Fill;
                p.Show();
            }
            else
            {
                panelMain.Controls.Clear();
                DetailMarkUNI p1 = new DetailMarkUNI();
                p1.TopLevel = false;
                panelMain.Controls.Add(p1);
                p1.Dock = DockStyle.Fill;
                p1.Show();
            }
        }
        private string getType()
        {
            string type = "";
            string query = "SELECT Tchr_Type FROM teacher_login where Tchr_ID='" + chiase.acc.getUser() + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                type = dr.GetValue(0).ToString();
                return type;
            }
        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Profile p1 = new Profile();
            p1.TopLevel = false;
            panelMain.Controls.Add(p1);
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            panelMain.Controls.Add(piclogo);

            LogoAni.ShowSync(piclogo);
        }

        private void btntotal_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            MarkUNI p1 = new MarkUNI();
            p1.TopLevel = false;
            panelMain.Controls.Add(p1);
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void btnpercent_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            person p1 = new person();
            p1.TopLevel = false;
            panelMain.Controls.Add(p1);
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            dashboard p1 = new dashboard();
            this.Hide();
            p1.Show();
        }
    }
}

