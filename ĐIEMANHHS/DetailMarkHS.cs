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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐIEMANHHS
{
    public partial class DetailMarkHS : Form
    {
        public DetailMarkHS()
        {
            InitializeComponent();
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void DetailMarkHS_Load(object sender, EventArgs e)
        {
            loadLop();
            loadStudent();
            txthocki.SelectedIndex = 0;
            cbtype.SelectedIndex = 0;
        }
        void loadStudent()
        {
            datahs.Rows.Clear();
            string query = "select * from detail_mark_hs";
            List<DetailHS> list = DataHelper.LoadDetailMarkHS(query);
            foreach (DetailHS item in list)
            {
                datahs.Rows.Add(item.getID(),item.getMaSV(), item.getMamon(), item.getLoai(), item.getMark(), item.getHocki());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtmahs.Text==""||txtmamon.Text=="")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (exedata("call sp_insDetailMarks_hs('" + chiase.acc.getUser() + "', '" + txtmahs.Text + "','" + txtmamon.Text + "','" + cbtype.Text + "','" + txtmark.Text + "','" + txthocki.SelectedIndex+1 + "')") == "1")
            {
                Alert("Thêm điểm thành công", showBiden.enmType.Success);
                loadStudent();
            }
            else
            {
                Alert("Thêm điểm thất bại", showBiden.enmType.Error);
                return;
            }
           
        }
        public static string id;
        private int index;
        private void datahs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            id = datahs.Rows[index].Cells[0].Value.ToString();
            cbtype.Text = datahs.Rows[index].Cells[3].Value.ToString();
            txtmark.Text = datahs.Rows[index].Cells[4].Value.ToString();
            txthocki.Text = datahs.Rows[index].Cells[5].Value.ToString();
        }
        private void loadLop()
        {
            string query = "select * from class_by_subject where CBS_Tchr_ID = '" + chiase.acc.getUser() + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                txtmamon.ValueMember = "CBS_ID";
                txtmamon.DataSource = dt;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                Alert("Chưa chọn giá trị để xóa", showBiden.enmType.Warning);
                return;
            }
            else
            {
                DialogResult dia = MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dia == DialogResult.Yes)
                {
                    if (exedata("call sp_deleteDetailMark_hs('" + chiase.acc.getUser() + "', '" + id + "')") == "1")
                    {
                        Alert("Đã xóa thành công", showBiden.enmType.Success);
                        loadStudent();
                    }
                    else
                    {
                        Alert("Xóa thất bại", showBiden.enmType.Error);
                        return;
                    }
                }
                
            }
        }
        public string exedata(string query)
        {
                string result = "";
                using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                {
                    connec.Open();
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand(query, connec);
                    MySqlDataAdapter data = new MySqlDataAdapter(cmd);
                    data.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        result = item["row_count()"].ToString();
                    }
                    return result;
               }
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (exedata("call sp_updateDetailMark_hs('" + chiase.acc.getUser() + "', '" + id + "','" + cbtype.Text + "','" + txtmark.Text + "','" + txthocki.Text + "')") == "1")
            {
                Alert("Cập nhập thành công", showBiden.enmType.Success);
                loadStudent();
            }
            else
            {
                Alert("Không thể cập nhập", showBiden.enmType.Error);
                return;
            }
        }

        private void txtmamon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
