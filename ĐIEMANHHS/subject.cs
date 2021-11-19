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
    public partial class subject : Form
    {
        public subject()
        {
            InitializeComponent();
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "" || txtmamon.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            Monhoc s = new Monhoc();
         
            s.setUser(chiase.acc.getUser().ToString());
            s.setMamon(txtmamon.Text.Trim());
            s.setName(txtname.Text.Trim());
            if (DataHelper.InsertSubject(s)=="1")
            {
                Alert("Thêm môn học thành công", showBiden.enmType.Success);
                loadSubject();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Success);
                return;
            }
           
        }

        private void subject_Load(object sender, EventArgs e)
        {
            loadSubject();
        }
        void loadSubject()
        {
            datasubject.Rows.Clear();
            string query = "select * from subject order by SJ_ID ASC";
            List<Subject> list = DataHelper.FindSubject(query);
            foreach (Subject item in list)
            {
                datasubject.Rows.Add(item.getID(), item.getName());
            }
        }
        private int index;
        public static string id;
        private void datasubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            id = datasubject.Rows[index].Cells[0].Value.ToString();
            txtmamon.Text = id;
            txtname.Text = datasubject.Rows[index].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                Alert("Chưa chọn để sửa", showBiden.enmType.Warning);
                return;
            }
            Monhoc s = new Monhoc();
          
            s.setUser(chiase.acc.getUser().ToString());
            s.setMamon(id);
            s.setName(txtname.Text.Trim());
            if (DataHelper.InsertSubject(s)=="1")
            {
                Alert("Sửa môn học thành công", showBiden.enmType.Success);
                loadSubject();
            }
            else
            {
                Alert("Sửa thất bại", showBiden.enmType.Error);
                return;
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string query = "call myclassroombiden.sp_deleteSubject('" + chiase.acc.getUser().ToString() + "', '" + id + "');";
            try
            {
                if (id == null)
                {
                    Alert("Chưa chọn để xóa", showBiden.enmType.Warning);
                    return;
                }
                DataHelper.DeleteSubject(query);
                Alert("Xóa môn học thành công", showBiden.enmType.Success);
                loadSubject();
            }
            catch
            {
                Alert("Xóa thất bại", showBiden.enmType.Error);
                return;
            }


        }

        private void btnout_sj_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(datasubject, saveFileDialog1.FileName);
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
