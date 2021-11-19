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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class LopTheoMon : Form
    {
        public LopTheoMon()
        {
            InitializeComponent();
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void LopTheoMon_Load(object sender, EventArgs e)
        {
            loadStudenHs();
            loadClass();
            loadStudenUni();
            string ad = getAdmin();
            string type = getType();
            if (ad == "1" && type == "1")
            {
                txtmasv.Enabled = false;
                txtlop.Enabled = false;
                btnaddstu.Enabled = false;
                btndeleteStudent.Enabled = false;
               
            }
            else if (ad == "1" && type == "2")
            {
                txths.Enabled = false;
                txtlophs.Enabled = false;
                btnaddhs.Enabled = false;
                btnxoahs.Enabled = false;
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
        void loadClass()
        {
            dataclass.Rows.Clear();
            string query = "select * from class_by_subject order by CBS_ID ASC";
            List<Class_Subject> list = DataHelper.FindClassSubject(query);
            foreach (Class_Subject item in list)
            {
                dataclass.Rows.Add(item.getMalop(), item.getMagv(), item.getMamon(), item.getHocki(), item.getNamhoc(), item.getSobuoi());
            }
        }
        void loadStudenUni()
        {
            dataStudent_Uni.Rows.Clear();
            string query = "select * from students_in_class_uni order by STT ASC";
            List<Student_Class_Uni> list = DataHelper.FindStudentClassSubject(query);
            foreach (Student_Class_Uni item in list)
            {
                dataStudent_Uni.Rows.Add(item.getId(), item.getName(), item.getLop());
            }
        }
        void loadStudenHs()
        {
            dataHS.Rows.Clear();
            string query = "select * from students_in_class_hs order by STT ASC";
            List<Student_Class_Uni> list = DataHelper.FindStudentClassSubject_Hs(query);
            foreach (Student_Class_Uni item in list)
            {
                dataHS.Rows.Add(item.getId(), item.getName(), item.getLop());
            }
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtbuoi.Text.Trim() == "" || txthocki.Text.Trim() == "" || txtmagv.Text.Trim() == "" || txtmalop.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.InsertClassSubject(txtmalop.Text.Trim(),ShareData.chiase.acc.getUser(), txtmagv.Text.Trim(), txtmamon.Text.Trim(),int.Parse(txthocki.Text.Trim()), txtyear.Text.Trim(),int.Parse(txtbuoi.Text.Trim()))=="1")
            {
                Alert("Thêm lớp thành công", showBiden.enmType.Success);
                loadClass();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Warning);
                return;
            }
        }

       
        private int index;
        public static string id;
        private void dataclass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                id = dataclass.Rows[index].Cells[0].Value.ToString();
                txtmalop.Text = id;
                txtmagv.Text = dataclass.Rows[index].Cells[1].Value.ToString();
                txtmamon.Text = dataclass.Rows[index].Cells[2].Value.ToString();
                txthocki.Text = dataclass.Rows[index].Cells[3].Value.ToString();
                txtyear.Text = dataclass.Rows[index].Cells[4].Value.ToString();
                txtbuoi.Text = dataclass.Rows[index].Cells[5].Value.ToString();
            }
            catch
            {

            }
         
        }
        int i;
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(id==null)
            {
                Alert("Chưa chọn để xóa", showBiden.enmType.Warning);
                return;
            }
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dia==DialogResult.Yes)
            {
                if (DataHelper.DeleteClassSubject(ShareData.chiase.acc.getUser(), txtmalop.Text.Trim()))
                {
                    Alert("Đã xóa thành công", showBiden.enmType.Success);
                    loadClass();
                }
                else
                {
                    Alert("Không thể xóa", showBiden.enmType.Error);
                    return;
                }
            }
            
        }

        private void btnaddstu_Click(object sender, EventArgs e)
        {
                i = 0;
                if (txtmasv.Text.Trim() == "" || txtlop.Text.Trim() == "")
                {
                    Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                    return;
                }
                MySqlConnection connec = new MySqlConnection(KetNoi.connection);
                connec.Open();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connec;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_insertStudInClassBySub_uni";
                cmd.Parameters.AddWithValue("AD_ID", chiase.acc.getUser());
                cmd.Parameters.AddWithValue("Student_ID", txtmasv.Text.Trim());
                cmd.Parameters.AddWithValue("ClassBySub_ID", txtlop.Text.Trim());
                MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                data.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    id = item["row_count()"].ToString();
                }
                if (id == "0")
                {

                    Alert("Không thể thêm dữ liệu", showBiden.enmType.Warning);
                }
                else
                {
                Alert("Thêm sinh viên theo lớp thành công", showBiden.enmType.Success);
                loadStudenUni();
                }
                connec.Close();

        }

        private void btndeleteStudent_Click(object sender, EventArgs e)
        {
         
            if (txtmasv.Text.Trim() == "" || txtlop.Text.Trim() == "")
            {
                Alert("Chưa chọn để xóa", showBiden.enmType.Warning);
                return;
            }
               DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dia == DialogResult.Yes)
            {
                if (DataHelper.DeleteStudentClassSubject(ShareData.chiase.acc.getUser(), txtmasv.Text.Trim(), txtlop.Text.Trim()))
                {
                    Alert("Đã xóa sinh viên theo lớp thành công", showBiden.enmType.Success);
                    loadStudenUni();
                }
                else
                {
                    Alert("Không thể xóa", showBiden.enmType.Error);
                    return;
                }
            }


        }
        
        private void dataStudent_Uni_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                txtmasv.Text = dataStudent_Uni.Rows[index].Cells[0].Value.ToString();
                txtlop.Text = dataStudent_Uni.Rows[index].Cells[2].Value.ToString();
            }
            catch
            {

            }
            
        }

        private void btnaddhs_Click(object sender, EventArgs e)
        {
            if (txths.Text.Trim() == "" || txtlophs.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.InsertStudentClassSubject_Hs(chiase.acc.getUser(), txths.Text.Trim(), txtlophs.Text.Trim())=="1")
            {
                Alert("Thêm học sinh theo lớp thành công", showBiden.enmType.Success);
                loadStudenHs();
            }
            else
            {
                Alert("Không thể thêm", showBiden.enmType.Error);
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnxoahs_Click(object sender, EventArgs e)
        {
            if (txths.Text.Trim() == "" || txtlophs.Text.Trim() == "")
            {
                Alert("Chưa chọn để xóa", showBiden.enmType.Warning);
                return;
            }
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dia == DialogResult.Yes)
            {
                if (DataHelper.DeleteStudentClassSubject_Hs(ShareData.chiase.acc.getUser(), txths.Text.Trim(), txtlophs.Text.Trim()))
                {
                    Alert("Đã xóa học sinh theo lớp thành công", showBiden.enmType.Success);
                    loadStudenHs();
                }
                else
                {
                    Alert("Không thể xóa", showBiden.enmType.Error);
                    return;
                }
            }
        }

        private void dataHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                txths.Text = dataHS.Rows[index].Cells[0].Value.ToString();
                txtlophs.Text = dataHS.Rows[index].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnout_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dataclass, saveFileDialog1.FileName);
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
