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
    public partial class ThongTin : Form
    {
        public ThongTin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void ThongTin_Load(object sender, EventArgs e)
        {
           
            loadFaculty();
            LoadSpeciality();
            loadClassUni();
            loadFa();
            loadFa1();
            CM();
        }

        private void btnaddfaculty_Click(object sender, EventArgs e)
        {
            if (txtIDfaculty.Text.Trim() == "" || txtnamefaculty.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if(DataHelper.InsertFaculty(chiase.acc.getUser(), txtIDfaculty.Text.Trim(), txtnamefaculty.Text.Trim())=="1")
            {
                Alert("Thêm khoa thành công", showBiden.enmType.Success);
                loadFaculty();
                loadFa();
                loadFa1();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Error);
                return;
            }
        }
        void loadFaculty()
        {
            DataFaculty.Rows.Clear();
            string query = "select * from faculty order by FCT_ID ASC";
            List<Faculty> list = DataHelper.FindFaculty(query);
            foreach (Faculty item in list)
            {
                DataFaculty.Rows.Add(item.getID(), item.getName());
            }
        }
        private void loadFa()
        {
            string query = "select * from faculty";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                txtidFa.DisplayMember = "FCT_Name";
                txtidFa.ValueMember = "FCT_ID";
                txtidFa.DataSource = dt;
            }

        }
        private void loadFa1()
        {
            string query = "select * from faculty";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                txtFaclass.DisplayMember = "FCT_Name";
                txtFaclass.ValueMember = "FCT_ID";
                txtFaclass.DataSource = dt;
            }

        }
        private void CM()
        {
            string query = "select * from speciality";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                txtspecClass.DisplayMember = "SPC_Name";
                txtspecClass.ValueMember = "SPC_ID";
                txtspecClass.DataSource = dt;
            }

        }
        private void btnaddspec_Click(object sender, EventArgs e)
        {
            if (txtspec.Text.Trim() == "" || txtnamespec.Text.Trim() == "" || txtidFa.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.InsertSpeciality(chiase.acc.getUser(), txtspec.Text.Trim(), txtnamespec.Text.Trim(), txtidFa.SelectedValue.ToString())=="1")
            {
                Alert("Thêm chuyên ngành thành công", showBiden.enmType.Success);
                LoadSpeciality();
                CM();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Error);
                return;
            }
        }
        void LoadSpeciality()
        {
            DataSpeciality.Rows.Clear();
            string query = "select * from speciality order by SPC_ID ASC";
            List<Speciality> list = DataHelper.FindSpeciality(query);
            foreach (Speciality item in list)
            {
                DataSpeciality.Rows.Add(item.getID(), item.getName(), item.getFaculty());
            }
        }

        private void btnaddClass_Click(object sender, EventArgs e)
        {
            if (txtclass.Text.Trim() == "" || txtspecClass.Text.Trim() == "" || txtFaclass.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
          
            if (DataHelper.InsertClassUni(chiase.acc.getUser(), txtclass.Text.Trim(), txtspecClass.SelectedValue.ToString(), txtFaclass.SelectedValue.ToString())=="1")
            {
                MessageBox.Show("Thêm lớp Đại Học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                loadClassUni();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Error);
                return;
            }
        }
        void loadClassUni()
        {
            DataClass.Rows.Clear();
            string query = "select * from class_uni order by CLU_ID ASC";
            List<Class_uni> list = DataHelper.FindClassUni(query);
            foreach (Class_uni item in list)
            {
                DataClass.Rows.Add(item.getID(), item.getSpec(), item.getFaculty());
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(DataClass, saveFileDialog1.FileName);
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
