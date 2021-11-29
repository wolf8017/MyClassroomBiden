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
    public partial class DetailMarkUNI : Form
    {
        public DetailMarkUNI()
        {
            InitializeComponent();
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void DetailMarkUNI_Load(object sender, EventArgs e)
        {
            cbtype.SelectedIndex = 0;
            loadStudent();
            Refreshcategory();
        }
        void loadStudent()
        {
            datahs.Rows.Clear();
            string query = "select * from detail_mark_uni where DMU_CBS_ID = '" + txtmamon.Text + "'";
            List<DetailHS> list = DataHelper.LoadDetailMarkUni(query);
            foreach (DetailHS item in list)
            {
                datahs.Rows.Add(item.getID(), item.getMaSV(), item.getMamon(), item.getLoai(), item.getMark());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmahs.Text == "" || txtmamon.Text == ""||txtmark.Text=="")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (exedata("call sp_insDetailMarks_uni('" + chiase.acc.getUser() + "', '" + txtmahs.Text + "','" + txtmamon.Text + "','" + cbtype.Text + "','" + txtmark.Text + "')") == "1")
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
        public static string id;
        private int index;
        private void datahs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            id = datahs.Rows[index].Cells[0].Value.ToString();
            cbtype.Text = datahs.Rows[index].Cells[3].Value.ToString();
            txtmark.Text = datahs.Rows[index].Cells[4].Value.ToString();
          
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (exedata("call sp_updateDetailMark_uni('" + chiase.acc.getUser() + "', '" + id + "','" + cbtype.Text + "','" + txtmark.Text + "')") == "1")
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
                    if (exedata("call sp_deleteDetailMark_uni('" + chiase.acc.getUser() + "', '" + id + "')") == "1")
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

        private void datahs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Refreshcategory()
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
                //txtmamon.DisplayMember = "foodname";
                txtmamon.ValueMember = "CBS_ID";
                txtmamon.DataSource = dt;
            }
        }

        private void txtmamon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtmamon.SelectedIndex.ToString() != null)
            {
                loadStudent();
            }
            else
            {
                loadStudent();
            }
        }
    }
}
