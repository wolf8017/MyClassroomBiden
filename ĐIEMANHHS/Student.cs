using Biden.Data;
using ĐIEMANHHS.Model;
using ĐIEMANHHS.ShareData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void Thongtin1_Load(object sender, EventArgs e)
        {

            string ad = getAdmin();
            string type = getType();
            if (ad == "1" && type == "1")
            {
                loadHS();
                loadTHPT();
            }
            else if (ad == "1" && type == "2")
            {
                loadStudent();
                loadUni();
            }
        }
        private void loadUni()
        {
            string query = "select * from class_uni";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";
                cbClass.ValueMember = "CLU_ID";
                cbClass.DataSource = dt;
            }
        }
        private void loadTHPT()
        {
            string query = "select * from class_hs";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";
                cbClass.ValueMember = "CLHS_ID";
                cbClass.DataSource = dt;
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
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "" || txtemail.Text.Trim() == "" || txtaddress.Text.Trim() == "" || txtphone.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            int parsedValue;
            if (!int.TryParse(txtphone.Text, out parsedValue))
            {
                Alert("Trường số điện thoại bắt buộc là số", showBiden.enmType.Warning);
                return;
            }
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(txtemail.Text))
            {
                Alert("Email không hợp lệ", showBiden.enmType.Warning);
                return;
            }

            if (DataHelper.InsertStudent(chiase.acc.getUser().ToString(), txtname.Text.Trim(), cbClass.Text.Trim(), day.Text.Trim(), rdNam.Checked ? "Nam" : "Nữ", txtaddress.Text.Trim(), txtphone.Text.Trim(), txtemail.Text.Trim()))
            {
                Alert("Thêm học sinh thành công", showBiden.enmType.Success);
                string ad = getAdmin();
                string type = getType();
                if (ad == "1" && type == "1")
                {
                    loadHS();

                }
                else if (ad == "1" && type == "2")
                {
                    loadStudent();
                }
            }
        }
        void loadStudent()
        {
            datastudent.Rows.Clear();
            string query = "select * from student_info_uni order by STT ASC";
            List<Student_Uni> list = DataHelper.FindStudentUni(query);
            foreach (Student_Uni item in list)
            {
                datastudent.Rows.Add(item.getID(), item.getName(), item.getClass(),item.getBOD(),item.getSex(),item.getAddress(),item.getPhone(),item.getMail());
            }
        }
        void loadHS()
        {
            datastudent.Rows.Clear();
            string query = "select * from student_info_hs order by STT ASC";
            List<Student_Uni> list = DataHelper.FindStudentHS(query);
            foreach (Student_Uni item in list)
            {
                datastudent.Rows.Add(item.getID(), item.getName(), item.getClass(), item.getBOD(), item.getSex(), item.getAddress(), item.getPhone(), item.getMail());
            }
        }
        private int index;
        public static string id;
        private void datastudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            id = datastudent.Rows[index].Cells[0].Value.ToString();
            txtname.Text = datastudent.Rows[index].Cells[1].Value.ToString();
            cbClass.Text = datastudent.Rows[index].Cells[2].Value.ToString();
            day.Text = datastudent.Rows[index].Cells[3].Value.ToString();
            string sex = datastudent.Rows[index].Cells[4].Value.ToString();
            if(sex=="Nam")
            {
                rdNam.Checked = true;
            }
            else
            {
                rdNu.Checked = true;
            }
            txtaddress.Text = datastudent.Rows[index].Cells[5].Value.ToString();
            txtphone.Text = datastudent.Rows[index].Cells[6].Value.ToString();
            txtemail.Text = datastudent.Rows[index].Cells[7].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "" || txtemail.Text.Trim() == "" || txtaddress.Text.Trim() == "" || txtphone.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            int parsedValue;
            if (!int.TryParse(txtphone.Text, out parsedValue))
            {
                Alert("Trường số điện thoại bắt buộc là số", showBiden.enmType.Warning);
                return;
            }
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(txtemail.Text))
            {
                Alert("Email không hợp lệ", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.UpdateStudent(chiase.acc.getUser().ToString(), id,txtname.Text.Trim(), cbClass.Text.Trim(), day.Text.Trim(), rdNam.Checked ? "Nam" : "Nữ", txtaddress.Text.Trim(), txtphone.Text.Trim(), txtemail.Text.Trim()))
            {
                Alert("Cập nhập thành công", showBiden.enmType.Success);
                string ad = getAdmin();
                string type = getType();
                if (ad == "1" && type == "1")
                {
                    loadHS();

                }
                else if (ad == "1" && type == "2")
                {
                    loadStudent();
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (id==null)
            {
                Alert("Chưa chọn để xóa", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.DeleteStudent(chiase.acc.getUser().ToString(), id))
            {
                Alert("Xóa học sinh thành công", showBiden.enmType.Success);
                string ad = getAdmin();
                string type = getType();
                if (ad == "1" && type == "1")
                {
                    loadHS();

                }
                else if (ad == "1" && type == "2")
                {
                    loadStudent();
                }
            }
        }

      

        private void button13_Click(object sender, EventArgs e)
        {
            //string searchValue = txtsearch.Text;

            //datastudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //try
            //{
            //    foreach (DataGridViewRow row in datastudent.Rows)
            //    {
            //        if (row.Cells[1].Value.ToString().Equals(searchValue))
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

        private void btnout_std_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(datastudent, saveFileDialog1.FileName);
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
