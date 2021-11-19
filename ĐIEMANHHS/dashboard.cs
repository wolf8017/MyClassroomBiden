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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (sidebar.Width == 204)
            {
                sidebar.Visible = false;
                sidebar.Width = 47;
                AnimationButton.ShowSync(sidebar);
            }
            else
            {
                sidebar.Visible = false;
                sidebar.Width = 204;
                AnimationButton.ShowSync(sidebar);

            }
        }

        private void btnkhoa_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            ThongTin p = new ThongTin();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Student p = new Student();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void goback_Click(object sender, EventArgs e)
        {
            Home p = new Home();
            this.Hide();
            p.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Login p = new Login();
            this.Hide();
            p.Show();
        }

        private void btngv_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Teacher p = new Teacher();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void btnclass_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            LopTheoMon p = new LopTheoMon();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            subject p = new subject();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            //loadLop();
           
            gv();
            mh();
            khoa();
            string ad = getAdmin();
            string type = getType();
            if (ad == "1" && type == "2")
            {
                bunifuFlatButton2.Visible = true;
                btnkhoa.Visible = true;
                btnlop.Visible = false;
                sv();
            }
            else
            {
                lbname.Text = "Học sinh";
                hs();
                bunifuFlatButton2.Visible = true;
                btnkhoa.Visible = false;
                btnlop.Visible = true;
                btnlop.Location = new Point(4, 254);
            }
            if (type == "1")
            {
                loadmarkHS(); 
                loadLop_hs();
               // comboBox1.SelectedIndex = 0;
            }
            else if (type == "2")
            {
                loadmark();
                loadLop();
                comboBox1.SelectedIndex = 0;
            }
        }
        //void log()
        //{
        //    string query = "select ID as 'ID',Activities as 'Hoạt động',onCreated as 'Vào lúc' from writelog order by ID desc limit 12";
        //    using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
        //    {
        //        connec.Open();
        //        MySqlCommand cmd = new MySqlCommand(query, connec);
        //        MySqlDataAdapter app = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        app.Fill(dt);
        //        connec.Close();
        //        writelog.DataSource = dt;
        //    }
        //}
        void loadmark()
        {

            //datastudent.Rows.Clear();
            string query = "Select mu.MU_STUD_ID as 'Mã SV', miu.STUD_Name as 'Tên sinh viên', mu.MU_GPA as 'Điểm trung bình',CASE When MU_GPA >= 8 THEN N'Giỏi' When MU_GPA >= 6.5 AND MU_GPA< 8 THEN N'Khá' When MU_GPA >= 5 AND MU_GPA< 6.5 THEN N'Trung bình' Else N'Yếu' End as 'Xếp loại' From marks_uni mu inner join student_info_uni miu on mu.MU_STUD_ID = miu.STUD_ID Where mu.MU_CBS_ID = '"+comboBox1.Text+"'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                writelog.DataSource = dt;
            }
        }
        void loadmarkHS()
        {

            //datastudent.Rows.Clear();
            string query = "Select ms.MHS_STUD_ID as 'Mã HS', mis.STUD_Name as 'Tên HS', ms.MHS_GPA as 'Điểm trung bình',CASE When MHS_GPA >= 8 THEN N'Giỏi' When MHS_GPA >= 6.5 AND MHS_GPA< 8 THEN N'Khá' When MHS_GPA >= 5 AND MHS_GPA< 6.5 THEN N'Trung bình' Else N'Yếu' End as 'Xếp loại' From marks_hs ms inner join student_info_hs mis on ms.MHS_STUD_ID = mis.STUD_ID Where ms.MHS_CBS_ID = '" + comboBox1.Text+"'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                writelog.DataSource = dt;
            }
        }
        void loadHS(string code)
        {

            //datastudent.Rows.Clear();
            string query = "Select ms.MHS_STUD_ID as 'Mã HS', mis.STUD_Name as 'Tên HS', ms.MHS_GPA as 'Điểm trung bình',CASE When MHS_GPA >= 8 THEN N'Giỏi' When MHS_GPA >= 6.5 AND MHS_GPA< 8 THEN N'Khá' When MHS_GPA >= 5 AND MHS_GPA< 6.5 THEN N'Trung bình' Else N'Yếu' End as 'Xếp loại' From marks_hs ms inner join student_info_hs mis on ms.MHS_STUD_ID = mis.STUD_ID Where ms.MHS_CBS_ID = '" + code + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                writelog.DataSource = dt;
            }
        }
        void loadrank(string code)
        {

            //datastudent.Rows.Clear();
            string query = "Select mu.MU_STUD_ID as 'Mã SV', miu.STUD_Name as 'Tên sinh viên', mu.MU_GPA as 'Điểm trung bình',CASE When MU_GPA >= 8 THEN N'Giỏi' When MU_GPA >= 6.5 AND MU_GPA< 8 THEN N'Khá' When MU_GPA >= 5 AND MU_GPA< 6.5 THEN N'Trung bình' Else N'Yếu' End as 'Xếp loại' From marks_uni mu inner join student_info_uni miu on mu.MU_STUD_ID = miu.STUD_ID Where mu.MU_CBS_ID = '" + code + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                writelog.DataSource = dt;
            }
        }
        DataSet load()
        {
            MySqlConnection connec = new MySqlConnection(KetNoi.connection);
            DataSet data = new DataSet();
            string query = "select * from marks_uni";
            MySqlCommand cmd = new MySqlCommand(query, connec);
            MySqlDataAdapter app = new MySqlDataAdapter(cmd);
            app.Fill(data);
            return data;
        }
        void gv()
        {
            string query = "select count(Tchr_ID) as tong from teacher_info";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lbgv.Text = rd["tong"].ToString();
                }
            }
        }
        void sv()
        {
            string query = "select count(STUD_ID) as tong from student_info_uni";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lbsv.Text = rd["tong"].ToString();
                }
            }
        }
        void hs()
        {
            string query = "select count(STUD_ID) as tong from student_info_hs";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lbsv.Text = rd["tong"].ToString();
                }
            }
        }
        void mh()
        {
            string query = "select count(SJ_ID) as tong from subject";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lbmh.Text = rd["tong"].ToString();
                }
            }
        }
        void khoa()
        {
            string query = "select count(FCT_ID) as tong from faculty";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();

                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lbkhoa.Text = rd["tong"].ToString();
                }
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            THPT p = new THPT();
            p.TopLevel = false;
            panelMain.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.Show();
        }
        private void loadLop()
        {
            string query = "Select distinct MU_CBS_ID From marks_uni";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                comboBox1.ValueMember = "MU_CBS_ID";
                comboBox1.DataSource = dt;
            }

        }

        private void loadLop_hs()
        {
            string query = "Select distinct MHS_CBS_ID From `marks_hs`";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                comboBox1.ValueMember = "MHS_CBS_ID";
                comboBox1.DataSource = dt;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() != null)
            {
                string Code = comboBox1.Text;
                
                string type = getType();
                if (type == "1")
                {

                    loadHS(Code);
                }
                else if (type == "2")
                {
                    loadrank(Code);
                }
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            dashboard d = new dashboard();
            this.Hide();
            d.Show();
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(writelog, saveFileDialog1.FileName);
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
                        worksheet.Cells[i + 2 , j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
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
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }

        private void writelog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
