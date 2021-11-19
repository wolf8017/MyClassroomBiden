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
    public partial class person : Form
    {
        public person()
        {
            InitializeComponent();
        }

        private void person_Load(object sender, EventArgs e)
        {
            loadperson();
            Refreshcategory();
        }
        void loadperson()
        {
            string query = "select MPU_CBS_ID as 'Lớp theo môn',MPU_Pratice_Percent as '% Thực hành',MPU_Exercise_Percent as '% Bài tập',MPU_Semi_Semester_Percent as '% Giữa kì' from marks_percent_uni";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataAdapter app = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                app.Fill(dt);
                connec.Close();
                //txtmamon.DisplayMember = "foodname";

                dataperson.DataSource = dt;
            }
        }
        public void Alert(string msg, showBiden.enmType type)
        {
            showBiden frm = new showBiden();
            frm.showAlert(msg, type);
        }
        private void btnadd_Click(object sender, EventArgs e)
        {

            if (txtBT.Text == "" || txtGK.Text == "" || txtmon.Text == ""||txtTH.Text=="")
            {
                Alert("Vui lòng điền đầy đủ thông tin", showBiden.enmType.Warning);
                return;
            }
            if (exedata("call myclassroombiden.sp_ins_updMarkPercent('" + txtmon.Text + "', '" + txtTH.Text + "','" + txtBT.Text + "','" + txtGK.Text + "')") == "1")
            {
                Alert("Thêm % điểm thành công", showBiden.enmType.Success);
                loadperson();
            }
            else
            {
                Alert("Thêm thất bại", showBiden.enmType.Error);
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
                txtmon.ValueMember = "CBS_ID";
                txtmon.DataSource = dt;
            }
        }
    }
}
