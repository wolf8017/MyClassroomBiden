
using ĐIEMANHHS.ShareData;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class MarkUNI : Form
    {
        public MarkUNI()
        {
            InitializeComponent();
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void MarkUNI_Load(object sender, EventArgs e)
        {
           
            loadLop();
            string type = getType();
            if (type == "1")
            {
                loadmarkhs();
            }
            else if (type == "2")
            {
                loadmark();
            }
        }
        void loadStudenUNI(string code)
        {

            //datastudent.Rows.Clear();
            string query = "select MU_ID as 'ID',MU_STUD_ID as 'Mã SV',MU_CBS_ID as 'Mã lớp theo môn',MU_Semi_Mark as 'Giữa kì',MU_Final_Mark as 'Cuối kì',MU_GPA as 'Thực hành' " +
                            "From marks_uni m inner join class_by_subject cls on m.MU_CBS_ID = cls.CBS_ID where MU_CBS_ID='" + code+ "' AND cls.CBS_Tchr_ID = '"+chiase.acc.getUser()+"' order by MU_ID ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datamark.DataSource = dt;
            }
        }
        void loadStudenHS(string code)
        {

            //datastudent.Rows.Clear();
            string query = "select MHS_ID as 'ID',MHS_STUD_ID as 'Mã SV',MHS_CBS_ID as 'Mã lớp theo môn',MHS_Semi_Mark as 'Giữa kì',MHS_Final_Mark as 'Cuối kì',MHS_GPA as 'Thường xuyên' from marks_hs where MHS_CBS_ID='" + code + "' order by MHS_ID ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datamark.DataSource = dt;
            }
        }
        void loadmarkhs()
        {

            //datastudent.Rows.Clear();
            string query = "select MHS_ID as 'ID',MHS_STUD_ID as 'Mã SV',MHS_CBS_ID as 'Mã lớp theo môn',MHS_Semi_Mark as 'Giữa kì',MHS_Final_Mark as 'Cuối kì',MHS_GPA as 'Thường xuyên' from marks_hs order by MHS_ID ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datamark.DataSource = dt;
            }
        }
        void loadmark()
        {

            //datastudent.Rows.Clear();
            string query = "select MU_ID as 'ID',MU_STUD_ID as 'Mã SV',MU_CBS_ID as 'Mã lớp theo môn',MU_Semi_Mark as 'Giữa kì',MU_Final_Mark as 'Cuối kì',MU_GPA as 'Thực hành' from marks_uni order by MU_ID ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datamark.DataSource = dt;
            }
        }
        private void loadLop()
        {
            string query = "select * from class_by_subject where CBS_Tchr_ID = '"+chiase.acc.getUser()+"'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                cbclass.ValueMember = "CBS_ID";
                cbclass.DataSource = dt;
            }

        }

        private void cbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex.ToString() != null)
            {
               string Code = cbclass.Text;
                string type = getType();
                if (type == "1")
                {
                    loadStudenHS(Code);
                }
                else if (type == "2")
                {
                    loadStudenUNI(Code);
                }
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

        private void btnout_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(datamark, saveFileDialog1.FileName);
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

        private void btnoutput_Click(object sender, EventArgs e)
        {
            if (datamark.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = cbclass.Text+".pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception)
                        {
                            ErrorMessage = true;
                            Alert("Không thể xuất dữ liệu", showBiden.enmType.Error);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(datamark.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in datamark.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in datamark.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            Alert("Xuất file PDF thành công", showBiden.enmType.Success);
                        }
                        catch (Exception)
                        {
                            Alert("Lỗi khi xuất dữ liệu", showBiden.enmType.Error);
                        }
                    }
                }
            }
            else
            {
                Alert("Không có dữ liệu", showBiden.enmType.Error);
            }
        }
       
    }
}
