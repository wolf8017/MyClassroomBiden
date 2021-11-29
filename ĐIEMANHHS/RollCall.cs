using Biden.Data;
using ĐIEMANHHS.Model;
using ĐIEMANHHS.ShareData;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class RollCall : Form
    {
   
     
        public RollCall()
        {
            InitializeComponent();
           
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
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
            if (txtbuoi.Text.Trim() == "" || txtmamon.Text.Trim() == "")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (DataHelper.InsertStudy(txtbuoi.Text.Trim(), datebatdau.Text.Trim(), dateketthuc.Text.Trim(),datengay.Text, chiase.acc.getUser(), txtmamon.Text.Trim()))
            {
                Alert("Thêm buổi học thành công", showBiden.enmType.Success);
                loadStudy();
            }
        }
        private void Refreshcategory()
        {
            string query = "select * from class_by_subject where CBS_Tchr_ID = '" + chiase.acc.getUser()+ "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";
                txtmamon.ValueMember = "CBS_ID";
                txtmamon.DataSource = dt;
            }
        }

        private void RefreshRoll(string code)
        {
            string query = "CALL myclassroombiden.sp_viewAttendance_uni('"+code+"')" +
                "";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                dataroll.DataSource = dt;
            }

        }
        private void RollCall_Load(object sender, EventArgs e)
        {
            loadStudy();      
            Refreshcategory();
            try {txtmamon.SelectedIndex = 0; }
            catch { }         
        }
        void loadStudy()
        {
            datastudy.Rows.Clear();
            string query = "select * from study where Tchr_ID = '"+chiase.acc.getUser()+"' And CBS_ID = '"+txtmamon.Text+"' order by ID ASC";
            List<Study> list = DataHelper.LoadStudy(query);
            foreach (Study item in list)
            {
                datastudy.Rows.Add(item.getBuoi(), item.getBatdau(), item.getKetthuc(), item.getNgay(), item.getMagv(), item.getMamon());
            }
        }
        void loadStudy_1(string code)
        {
            datastudy.Rows.Clear();
            string query = "select * from study where Tchr_ID = '" + chiase.acc.getUser() + "' And CBS_ID = '" + code + "' order by ID ASC";
            List<Study> list = DataHelper.LoadStudy(query);
            foreach (Study item in list)
            {
                datastudy.Rows.Add(item.getBuoi(), item.getBatdau(), item.getKetthuc(), item.getNgay(), item.getMagv(), item.getMamon());
            }
        }
        void loadStudenUni(string code)
        {
           
            //datastudent.Rows.Clear();
            string query = "select SIC_STUD_ID as 'Mã SV',SIC_STUD_Name as 'Tên sinh viên',SIC_CBS_ID 'Lớp theo môn' from students_in_class_uni where SIC_CBS_ID='" + code+"' order by STT ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datastudent.DataSource = dt;
            }
        }
        void loadStudenHS(string code)
        {

            //datastudent.Rows.Clear();
            string query = "select SIC_STUD_ID,SIC_STUD_Name,SIC_CBS_ID from students_in_class_hs where SIC_CBS_ID='" + code + "' order by STT ASC";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                datastudent.DataSource = dt;
            }
        }
        void loadRoll(string code)
        {
            dataroll.Rows.Clear();
            string query = "select * from study_status_uni where SSU_CBS_ID='"+code+ "' Order by SSU_ID DESC";
            List<Roll> list = DataHelper.LoadRollCall(query);
            foreach (Roll item in list)
            {
                dataroll.Rows.Add(item.getMasv(), item.getName(), item.getLop(), item.getBuoi(), item.getGio(), item.getNgay(), item.getStatus());
            }
        }
        void loadRollHS(string code)
        {
            dataroll.Rows.Clear();
            string query = "select * from study_status_hs where SSHS_CBS_ID='"+ code + "' Order by SSHS_ID DESC";
            List<Roll> list = DataHelper.LoadRollCallHS(query);
            foreach (Roll item in list)
            {
                dataroll.Rows.Add(item.getMasv(), item.getName(), item.getLop(), item.getBuoi(), item.getGio(), item.getNgay(), item.getStatus());
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (txtbuoi.Text.Trim() == "" || txtmamon.Text.Trim() == "")
            {
                Alert("Chưa chọn giá trị để xóa", showBiden.enmType.Warning);
                return;
            }
            DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dia == DialogResult.Yes)
            {
                if (DataHelper.DeleteBuoi(chiase.acc.getUser(), txtbuoi.Text.Trim(), txtmamon.Text.Trim()))
                {
                    Alert("Đã xóa buổi học thành công", showBiden.enmType.Success);
                    loadStudy();
                }
                else
                {
                    Alert("Xóa thất bại", showBiden.enmType.Error);
                    return;
                }
            }
        }

        private void dataroll_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataroll.Rows)
            {
                string check = row.Cells[6].Value.ToString();
                if (check == "Vắng")
                {
                    row.Cells[6].Style.BackColor = Color.Red;
                    row.Cells[6].Style.ForeColor = Color.White;
                }
                if (check == "Có mặt")
                {
                    row.Cells[6].Style.BackColor = Color.Green;
                    row.Cells[6].Style.ForeColor = Color.White;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = getType();
            if (type == "1")
            {
                if (id == null)
                {
                    Alert("Chưa chọn học sinh để điểm danh", showBiden.enmType.Warning);
                    return;
                }
                else
                {
                    if (DataHelper.DiemDanhHS(chiase.acc.getUser(), id, mamon, "Có mặt"))
                    {
                        loadRollHS(txtmamon.Text);
                    }
                }
            }
            else if (type == "2")
            {
                if (id == null)
                {
                    Alert("Chưa chọn sinh viên để điểm danh", showBiden.enmType.Warning);
                    return;
                }
                else
                {
                    if (DataHelper.DiemDanh(chiase.acc.getUser(), id, mamon, "Có mặt"))
                    {

                        loadRoll(txtmamon.Text);
                    }
                }
            }    
        }
        private int index;
        public static string id;
        public static string mamon;
        private void datastudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                id = datastudent.Rows[index].Cells[0].Value.ToString();
                mamon = datastudent.Rows[index].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string type = getType();
            if (type == "1")
            {
                if (id == null)
                {
                    Alert("Chưa chọn học sinh để điểm danh", showBiden.enmType.Warning);
                    return;
                }
                else
                {
                    if (DataHelper.DiemDanhHS(chiase.acc.getUser(), id, mamon, "Vắng"))
                    {
                        loadRollHS(txtmamon.Text);
                    }
                }
            }
            else if (type == "2")
            {
                if (id == null)
                {
                    Alert("Chưa chọn sinh viên để điểm danh", showBiden.enmType.Warning);
                    return;
                }
                else
                {
                    if (DataHelper.DiemDanh(chiase.acc.getUser(), id, mamon, "Vắng"))
                    {
                        loadRoll(txtmamon.Text);
                    }
                }
            }
        }

        private void datastudy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            txtbuoi.Text = datastudy.Rows[index].Cells[0].Value.ToString();
            txtmamon.Text = datastudy.Rows[index].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (OleDbConnection myConnect = new OleDbConnection(string.Format(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", openFileDialog1.FileName)))
                    {
                        Application.DoEvents();
                        DataTable dt = new DataTable();
                        OleDbDataAdapter cmd = new OleDbDataAdapter("select * from [Sheet1$]", myConnect);
                        cmd.Fill(dt);
                        datastudent.DataSource = dt;
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static string Code;
        private void txtmamon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtmamon.SelectedIndex.ToString() != null)
            {
                Code = txtmamon.Text;
                string type = getType();
                if (type == "1")
                {
                    loadStudenHS(Code);
                    loadRollHS(Code);
                    loadStudy_1(Code);
                }
                else if (type == "2")
                {
                    loadStudenUni(Code);
                    loadRoll(Code);
                    loadStudy_1(Code);
                }
            }
        }
    }
}
