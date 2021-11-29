using Biden.Data;
using Biden.Model;
using ĐIEMANHHS.Model;
using ĐIEMANHHS.ShareData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        private Account account;
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void Teacher_Load(object sender, EventArgs e)
        {
         
         
            load();

        }
        void load()
        {
            DataTeacher.Rows.Clear();
            string query = "SELECT * FROM myclassroombiden.teacher_info";
            List<TeacherInfo> list = DataHelper.FindTeacher(query);
            foreach (TeacherInfo item in list)
            {
                DataTeacher.Rows.Add(item.getID(), item.getName(), item.getBOD(), item.getSex(), item.getAddress(), item.getPhone(), item.getMail(), item.getRole(), item.getSchool());
            }

        }
        //ramdom pass
        public static string RandomChar(int numberRD)
        {
            string randomStr = "";
            try
            {

                string[] myIntArray = new string[numberRD];
                int x;
                Random autoRand = new Random();
                for (x = 0; x < numberRD; x++)
                {
                    myIntArray[x] = Convert.ToChar(Convert.ToInt32(autoRand.Next(65, 87))).ToString();
                    randomStr += (myIntArray[x].ToString());
                }
            }
            catch (Exception ex)
            {
                randomStr = "error";
            }
            return randomStr;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(txtmail.Text))
            {
                Alert("Email không hợp lệ", showBiden.enmType.Warning);
                return;
            }
            string pass = RandomChar(6);
            account = new Account();
            account.setUser(chiase.acc.getUser());
            account.setEmail(txtmail.Text.Trim());
            account.setPass(pass);
            account.setType((cbtype.SelectedIndex) + 1);
            account.setAdmin(cbadmin.SelectedIndex);
            account.setRole(txtrole.Text.Trim());
            if (DataHelper.InsertAccount(account)=="1")
            {
                Alert("Thêm thành công", showBiden.enmType.Success);
                load();
                string tk = "";
                string query = "Select Tchr_ID, Tchr_Pass From teacher_login Order by STT desc Limit 1";
                using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                {
                    connec.Open();
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand(query, connec);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                    data.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        tk = item["Tchr_ID"].ToString();
                    }
                    addsendmail(txtmail.Text.Trim(), tk, pass);
                }
            }
            else
            {
                Alert("Không thể thêm", showBiden.enmType.Error);
                return;
            }
        }
        void addsendmail(string to,string tk,string pass)
        {
            string go = "locchicken197@gmail.com";
            string title = "Tài khoản đăng nhập";
            string content = "Thông tin tài khoản đăng nhập vào hệ thống của bạn, " + "Tài khoản: " + tk + ", Mật khẩu: " + pass;
            Thread t = new Thread(() =>
            {
                try
                {

                    MailMessage mail = new MailMessage(go,to, title,content);

                    SmtpClient smtp = new SmtpClient()
                    {
                        //Máy chủ smtp
                        Host = "smtp.gmail.com",
                        //Cổng gửi thư
                        Port = 587,
                        //Tài khoản Gmail
                        Credentials = new NetworkCredential(go, "scupkqupkczfjtav"),
                        EnableSsl = true
                    };

                    smtp.Send(mail);
                    Alert("Đã gửi tài khoản của bạn về mail", showBiden.enmType.Success);

                }
                catch (Exception ex)
                {
                    Alert("Không thể gửi", showBiden.enmType.Warning);
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {

        }
        //void write()
        //{
        //    writelog.Rows.Clear();
        //    string query = "SELECT * FROM myclassroombiden.writelog order by ID desc";
        //    List<WriteLog> list = DataHelper.FindWriteLog(query);
        //    foreach (WriteLog item in list)
        //    {
        //        writelog.Rows.Add(item.getActive(), item.getTime());
        //    }
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(id==null)
            {
                Alert("Chưa chọn để cập nhập", showBiden.enmType.Warning);
                return;
            }
            else
            {
                UpdateTeacher up = new UpdateTeacher();
                up.ShowDialog();
            }
        }
        private static string id;
        private int index;
        private void DataTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                id = DataTeacher.Rows[index].Cells[0].Value.ToString();
                TeacherInfo teacher = new TeacherInfo();

                account = DataHelper.FindAccountID(id);
                teacher = DataHelper.FindTeacherID(id);
                if (teacher != null || account != null)
                {
                    txtrole.Text = teacher.getRole();

                    int admin = account.getAdmin();
                    chiase.acc = account;
                    LayTeacher.info = teacher;
                    if (admin == 0)
                    {
                        cbadmin.SelectedIndex = cbadmin.FindStringExact("Không");
                    }
                    else if (admin == 1)
                    {
                        cbadmin.SelectedIndex = cbadmin.FindStringExact("Admin");
                    }

                }
            }
            catch (Exception)
            {

            }
            
                              
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            load();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

       

        private void btnguimail_Click(object sender, EventArgs e)
        {
        //    if(txtthread.Text=="")
        //    {
        //        MessageBox.Show("Cần chọn số luồng để chạy!", "Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if(txtcontent.Text=="")
        //    {
        //        MessageBox.Show("Nội dung không được để trống!", "Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    try
        //    {
        //        maxThread = int.Parse(txtthread.Text);
        //    }
        //    catch (Exception)
        //    {
        //        maxThread = 1;
        //    }
        //    new Thread(delegate ()
        //    {
        //        if (maxThread > 0)
        //        {
        //            guimail();
        //        }
        //    })
        //    {
        //        IsBackground = true
        //    }.Start();

            
        }
        void guimail()
        {
            int i = 0;
            while (i < DataTeacher.Rows.Count)
            {
                if (countThread < maxThread)
                {
                    int gt = i;
                    new Thread(delegate ()
                    {
                        checkMail(DataTeacher[6, gt].Value.ToString(),gt);
                    }).Start();
                    countThread++;//tăng lên 1 luồng
                    i++;
                }
            }
            countThread = 0;
        }
        public void checkMail(string to,int place)
        {
            try
            {
                DataTeacher.Rows[place].Cells["status"].Value = "Đang request server";
                DataTeacher.Rows[place].DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 102);
                string go = "locchicken197@gmail.com";
                string title = "Myclassroom Biden";
               
                MailMessage mail = new MailMessage(go,to, title, txtcontent.Text);

                SmtpClient smtp = new SmtpClient()
                {
                    //Máy chủ smtp
                    Host = "smtp.gmail.com",
                    //Cổng gửi thư
                    Port = 587,
                    //Tài khoản Gmail
                    Credentials = new NetworkCredential(go, "scupkqupkczfjtav"),
                    EnableSsl = true
                };

                smtp.Send(mail);
                DataTeacher.Rows[place].Cells["status"].Value = "Đã gửi";
                DataTeacher.Rows[place].DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 127);
                DataTeacher.Rows[place].DefaultCellStyle.ForeColor = Color.Black;
            }
            catch
            {
                DataTeacher.Rows[place].Cells["status"].Value = "Lỗi";
                DataTeacher.Rows[place].DefaultCellStyle.BackColor = Color.FromArgb(255, 106, 106);
                DataTeacher.Rows[place].DefaultCellStyle.ForeColor = Color.Black;
            }
            countThread--;
            
        }
        public int countThread;//đếm luồng
        public int maxThread;//số luồng đang chạy

        private void button1_Click(object sender, EventArgs e)
        {
            //string searchValue = textBox1.Text;

            //DataTeacher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //try
            //{
            //    foreach (DataGridViewRow row in DataTeacher.Rows)
            //    {
            //        if (row.Cells[0].Value.ToString().Equals(searchValue))
            //        {
            //            row.Selected = true;
            //            break;
            //        }
            //    }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
        }

        private void btnmail_Click(object sender, EventArgs e)
        {
            if (txtthread.Text == "")
            {
                Alert("Cần nhập số luồng chạy", showBiden.enmType.Warning);
                return;
            }
            if (txtcontent.Text == "")
            {
                Alert("Nội dung không được trống", showBiden.enmType.Warning);
                return;
            }
            try
            {
                maxThread = int.Parse(txtthread.Text);
            }
            catch (Exception)
            {
                maxThread = 1;
            }
            new Thread(delegate ()
            {
                if (maxThread > 0)
                {
                    guimail();
                }
            })
            {
                IsBackground = true
            }.Start();
        }

        private void btnout_tchr_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(DataTeacher, saveFileDialog1.FileName);
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "LIBRARY BIDEN";
                // export header
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export content
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                Alert("Xuất file thành công", showBiden.enmType.Success);
            }
            catch (Exception ex)
            {
                Alert(ex.Message, showBiden.enmType.Error);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
