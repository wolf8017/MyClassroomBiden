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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool dragging;
        private Point pointClicked;
       
        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backGround1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point pointMoveTo;
                pointMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                pointMoveTo.Offset(-pointClicked.X, -pointClicked.Y);
                this.Location = pointMoveTo;
            }
        }

        private void backGround1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pointClicked = new Point(e.X, e.Y);
            }
            else
            {
                dragging = false;
            }
        }

        private void backGround1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void backGround1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.tk != string.Empty)
            {
                txtuser.Text = Properties.Settings.Default.tk;
                txtpass.Text = Properties.Settings.Default.mk;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "" || txtpass.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (!checkBox1.Checked)
            {
                DialogResult d = MessageBox.Show("Bạn có muốn lưu tài khoản mật khẩu không", "Thông báo", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                    checkBox1.Checked = true;
                Thread t = new Thread(() =>
                {
                    Invoke(new Action(() =>
                    {
                        string query = "select * from teacher_login where Tchr_ID='" + txtuser.Text.Trim() + "' and Tchr_Pass='" + txtpass.Text.Trim() + "'";
                        int i;
                        using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                        {
                            i = 0;
                            connec.Open();
                            MySqlCommand cmd = new MySqlCommand(query, connec);
                            DataTable dt = new DataTable();
                            cmd.ExecuteNonQuery();
                            MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                            app.Fill(dt);
                            i = Convert.ToInt32(dt.Rows.Count.ToString());
                            if (i == 0)
                            {
                                Alert("Tài khoản hoặc mật khẩu không chính xác", showBiden.enmType.Error);
                            }
                            else
                            {
                                Account acc = new Account();
                                acc.setUser(txtuser.Text.Trim());
                                acc.setPass(txtpass.Text.Trim());
                                chiase.acc = acc;
                                Home tt = new Home();
                                this.Hide();
                                tt.Show();
                                
                            }
                            saveAccount();
                        }
                    }));
                });
                t.IsBackground = true;
                t.Start();
            }
            else
            {
                Thread t = new Thread(() =>
                {
                    Invoke(new Action(() =>
                    {
                        string query = "select * from teacher_login where Tchr_ID='" + txtuser.Text.Trim() + "' and Tchr_Pass='" + txtpass.Text.Trim() + "'";
                        int i;
                        using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                        {
                            i = 0;
                            connec.Open();
                            MySqlCommand cmd = new MySqlCommand(query, connec);
                            DataTable dt = new DataTable();
                            cmd.ExecuteNonQuery();
                            MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                            app.Fill(dt);
                            i = Convert.ToInt32(dt.Rows.Count.ToString());
                            if (i == 0)
                            {
                                Alert("Tài khoản hoặc mật khẩu không chính xác", showBiden.enmType.Error);
                            }
                            else
                            {
                                Account acc = new Account();
                                acc.setUser(txtuser.Text.Trim());
                                acc.setPass(txtpass.Text.Trim());
                                chiase.acc = acc;
                                Home tt = new Home();
                                this.Hide();
                                tt.Show();

                            }
                            saveAccount();
                        }
                    }));
                });
                t.IsBackground = true;
                t.Start();
            }

            
        }
        void saveAccount()
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.tk = txtuser.Text;
                Properties.Settings.Default.mk = txtpass.Text;
                Properties.Settings.Default.Save();
            }
            if (checkBox1.Checked == false)
            {
                Properties.Settings.Default.tk = "";
                Properties.Settings.Default.mk = "";
                Properties.Settings.Default.Save();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
