using Biden.Model;
using ĐIEMANHHS;
using ĐIEMANHHS.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biden.Data
{
    public class DataHelper
    {
        
        //load teacher_Info
        public static List<TeacherInfo> FindTeacher(string query)
        {
           
                using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                {
                    connec.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connec);
                    MySqlDataReader data = cmd.ExecuteReader();
                    List<TeacherInfo> list = new List<TeacherInfo>();
                    while (data.Read() == true)
                    {
                 
                        TeacherInfo teacher = new TeacherInfo();
                        teacher.setID(data.GetString("Tchr_ID"));
                        if (!data.IsDBNull(1))
                        {
                             teacher.setName(data.GetString("Tchr_Name"));
                         }
                        if(!data.IsDBNull(2))
                        {
                            teacher.setSex(data.GetString("Tchr_Sex"));
                        }
                        if (!data.IsDBNull(4))
                        {
                            teacher.setAddress(data.GetString("Tchr_Address"));
                        }
                        if (!data.IsDBNull(5))
                        {
                            teacher.setPhone(data.GetString("Tchr_Phone"));
                        }
                        teacher.setBOD(data.GetString("Tchr_BOD"));
                        teacher.setMail(data.GetString("Tchr_Mail"));
                        teacher.setRole(data.GetString("Tchr_Role"));
                        teacher.setSchool(data.GetInt32("Tchr_inSchool"));
                        list.Add(teacher);
                      }
                    return list;
                }
           
           
        }

        //insert teacher_info
        public static Boolean InsertTearcher(TeacherInfo teacher)
        {
            string id = teacher.getID();
            string name = teacher.getName();
            string sex = teacher.getSex();
            string bod = teacher.getBOD();
            string address = teacher.getAddress();
            string phone = teacher.getPhone();
            string mail = teacher.getMail();
            string role = teacher.getRole();
            string query = "insert myclassroombiden.teacher_info(Tchr_ID,Tchr_Name,Tchr_Sex,Tchr_BOD,Tchr_Address,Tchr_Phone,Tchr_Mail,Tchr_Role) values('" + id + "',N'" + name + "',N'" + sex + "','" + bod + "','" + address + "','" + phone + "','" + mail + "','" + role + "')";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //load tài khoản
        public static List<Account> FindAccount(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Account> list = new List<Account>();
                while (data.Read() == true)
                {
                    Account teacher = new Account();
                    teacher.setID(data.GetString("STT"));
                    teacher.setUser(data.GetString("Tchr_ID"));
                    teacher.setPass(data.GetString("Tchr_Pass"));
                    teacher.setAdmin(data.GetInt32("isAdmin"));
                    teacher.setType(data.GetInt32("Tchr_Type"));
                    
                    list.Add(teacher);
                }
                return list;
            }
        }
        public static Account FindProfile(string id)
        {
            string query = "select * from teacher_info where Tchr_ID = '" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Account> list = new List<Account>();
                if (data.Read() == true)
                {
                    Account teacher = new Account();         
                    teacher.setUser(data.GetString("Tchr_ID"));         
                    teacher.setEmail(data.GetString("Tchr_Mail"));
                    teacher.setRole(data.GetString("Tchr_Role"));
                    
                    teacher.setNgaySinh(data.GetString("Tchr_BOD"));
                    if (!data.IsDBNull(1))
                    {
                        teacher.setName(data.GetString("Tchr_Name"));
                    }
                    if (!data.IsDBNull(2))
                    {
                        teacher.setSex(data.GetString("Tchr_Sex"));
                    }
                    if (!data.IsDBNull(4))
                    {
                        teacher.setAddress(data.GetString("Tchr_Address"));
                    }
                    if (!data.IsDBNull(5))
                    {
                        teacher.setPhone(data.GetString("Tchr_Phone"));
                    }
                    return teacher;
                }
                return null;
            }
        }
        //update profile
        public static string UpdateProfile(Account account)
        {
            string result = "";
            string user = account.getUser();
            string name = account.getName();
            string sex = account.getSex();
            string ngay = account.getNgaySinh();
            string address = account.getAddress();
            string phone = account.getPhone();
            string email = account.getEmail();
            string query = "Call myclassroombiden.sp_updateTeacher('"+user+"','"+name+"','"+ sex + "','"+ngay+"','"+address+"','"+ phone + "','"+ email + "')";
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
        //thêm tài khoản
        public static string InsertAccount(Account account)
        {
            string result = "";
            string user = account.getUser();
            string mail = account.getEmail();
            string pass = account.getPass();
            int type = account.getType();
            int admin = account.getAdmin();
            string role = account.getRole();
            string query = "call myclassroombiden.sp_insertTeacher('"+ user + "',N'"+mail+"', N'"+pass+"', "+type+", "+admin+", N'"+role+"');";
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
        //xóa tài khoản
        public static Boolean DeleteAccount(Account account)
        {
            string id = account.getID();
            string query = "delete from myclassroombiden.teacher_login where STT='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //update tài khoản
        //public static Boolean UpdateAccount(Account account)
        //{
        //    string id = account.getID();
        //    string user = account.getUser();
        //    string pass = account.getPass();
        //    int isadmin = account.getIsAdmin();
        //    string query = "update myclassroombiden.teacher_login set Tchr_ID='" + user + "',Tchr_Pass='" + pass + "',isAdmin='" + isadmin + "' where STT='" + id + "'";
        //    using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
        //    {
        //        connec.Open();
        //        MySqlCommand cmd = new MySqlCommand(query, connec);
        //        return cmd.ExecuteNonQuery() > 0;
        //    }
        //}

        //load tài khoản theo id
        public static Account FindAccountID(string id)
        {
            string query = "select* from teacher_login where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    Account account = new Account();
                    account.setID(data.GetString("STT"));
                    account.setUser(data.GetString("Tchr_ID"));
                    account.setAdmin(data.GetInt32("isAdmin"));
                    account.setType(data.GetInt32("Tchr_Type"));
                    return account;
                }
                return null;
            }
        }
        //check tồn tại trong teacher
        public static TeacherInfo FindTeacherID(string id)
        {
            string query = "select* from teacher_info where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    TeacherInfo teacher = new TeacherInfo();
                    teacher.setID(data.GetString("Tchr_ID"));
                    teacher.setRole(data.GetString("Tchr_Role"));
                    teacher.setSchool(data.GetInt32("Tchr_inSchool"));
                    return teacher;
                }
                return null;
            }
        }

        //
        public static Account Findacc(string id)
        {
            string query = "select* from teacher_login where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    Account teacher = new Account();
                    teacher.setAdmin(data.GetInt32("isAdmin"));
                  
                    return teacher;
                }
                return null;
            }
        }
        //update teacher
        public static Boolean UpdateTeacher(TeacherInfo teacher)
        {
            string id = teacher.getID();
            string name = teacher.getName();
            string sex = teacher.getSex();
            string bod = teacher.getBOD();
            string address = teacher.getAddress();
            string phone = teacher.getPhone();
            string mail = teacher.getMail();
            string role = teacher.getRole();
            string query = "update myclassroombiden.teacher_info set Tchr_Name='" + name + "',Tchr_Sex='" + sex + "',Tchr_BOD='" + bod + "',Tchr_Address='" + address + "',Tchr_Phone='" + phone + "',Tchr_Mail='" + mail + "',Tchr_Address='" + address + "' where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //xóa teacher
        public static Boolean DeleteTeacher(TeacherInfo teacher)
        {
            string id = teacher.getID();
            string query = "delete from myclassroombiden.teacher_info where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //load khoa
        public static List<Faculty> FindFaculty(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Faculty> list = new List<Faculty>();
                while (data.Read() == true)
                {
                    Faculty Fc = new Faculty();
                    Fc.setID(data.GetString("FCT_ID"));
                    Fc.setName(data.GetString("FCT_Name"));
                    list.Add(Fc);
                }
                return list;
            }
        }
        //thêm khoa
        public static string InsertFaculty(string user,string id,string name)
        {
            string result = "";
            string query = "call myclassroombiden.sp_insertFaculty('"+ user + "', '"+id+"', N'"+name+"');";
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
        //update khoa
        public static Boolean UpdateFaculty(Faculty Fc)
        {
            string id = Fc.getID();
            string name = Fc.getName();
            string query = "update myclassroombiden.faculty set FCT_ID='" + id + "',FCT_Name='" + name + "' where FCT_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //xóa khoa
        public static Boolean DeleteFaculty(Faculty Fc)
        {
            string id = Fc.getID();
            string query = "delete from myclassroombiden.faculty where FCT_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //load chuyên ngành
        public static List<Speciality> FindSpeciality(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Speciality> list = new List<Speciality>();
                while (data.Read() == true)
                {
                    Speciality Fc = new Speciality();
                    Fc.setID(data.GetString("SPC_ID"));
                    Fc.setName(data.GetString("SPC_Name"));
                    Fc.setFaculty(data.GetString("SPC_Faculty"));
                    list.Add(Fc);
                }
                return list;
            }
        }
        //thêm chuyên ngành
        public static string InsertSpeciality(string user,string id,string name,string idFa)
        {
            string result = "";
            string query = "call myclassroombiden.sp_insertSpeciality('" + user + "', '" + id + "', N'" + name + "','"+idFa+"');";
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
        //update chuyên ngành
        public static Boolean UpdateSpeciality(Speciality sp)
        {
            string id = sp.getID();
            string name = sp.getName();
            string faculty = sp.getFaculty();
            string query = "update myclassroombiden.speciality set SPC_Name='" + name + "',SPC_Faculty='" + faculty + "' where SPC_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //xóa chuyên ngành
        public static Boolean DeleteSpeciality(Speciality sp)
        {
            string id = sp.getID();
            string query = "delete from myclassroombiden.speciality where SPC_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        //load lớp đại học
        public static List<Class_uni> FindClassUni(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Class_uni> list = new List<Class_uni>();
                while (data.Read() == true)
                {
                    Class_uni Fc = new Class_uni();
                    Fc.setID(data.GetString("CLU_ID"));
                    Fc.setSpec(data.GetString("CLU_Speciality"));
                    Fc.setFaculty(data.GetString("CLU_Faculty"));
                    list.Add(Fc);
                }
                return list;
            }
        }
        //thêm lớp đại học
        public static string InsertClassUni(string user, string idclass, string idspec, string idFa)
        {
            string result="";
            string query = "call myclassroombiden.sp_insertClass_UNI('" + user + "', '" + idclass + "', N'" + idspec + "','" + idFa + "');";
           
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
        //update lớp đại học
        public static Boolean UpdateClassUni(Class_uni u)
        {
            string id = u.getID();
            string spec = u.getSpec();
            string faculty = u.getFaculty();
            string query = "update myclassroombiden.class_uni set CLU_Speciality='" + spec + "',CLU_Faculty='" + faculty + "' where CLU_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        //xóa lớp đại học
        public static Boolean DeleteClassUni(Class_uni u)
        {
            string id = u.getID();
            string query = "delete from myclassroombiden.class_uni where CLU_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public static List<WriteLog> FindWriteLog(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<WriteLog> list = new List<WriteLog>();
                while (data.Read() == true)
                {
                    WriteLog wr = new WriteLog();
                    wr.setActive(data.GetString("Activities"));
                    wr.setTime(data.GetString("onCreated"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //update
        public static string updateGiaovien(string user,string id,string role,int in_skl)
        {
            string result = "";
            string query = "call myclassroombiden.sp_updateRole_Work('" + user + "',N'" + id + "', N'" + role + "', " + in_skl + ");";
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
        //checkpass
        public static Account CheckPass(string user,string pass)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                string query = "call myclassroombiden.sp_teacherLogin('" + user + "', '" + pass + "');";
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    Account acc = new Account();
                    acc.setPass(pass);
                    return acc;
                }
            }
            return null;
        }
        //changePass
        public static string changePass(string user, string pass,string passnew)
        {
            string result = "";
            string query = "call myclassroombiden.sp_changePassword('" + user + "', '" + pass + "','"+passnew+"');";
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
        //THPT
        public static List<ClassTHPT> FindTHPT(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<ClassTHPT> list = new List<ClassTHPT>();
                while (data.Read() == true)
                {
                    ClassTHPT Fc = new ClassTHPT();
                    Fc.setID(data.GetString("CLHS_ID"));
                    list.Add(Fc);
                }
                return list;
            }
        }
        //thêm chuyên ngành
        public static string InsertTHPT(string user,string id)
        {
            string result = "";
            string query = "call myclassroombiden.sp_insertClass_HS('" + user + "', '" + id + "');";
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
        //student uni
        public static List<Student_Uni> FindStudentUni(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Student_Uni> list = new List<Student_Uni>();
                while (data.Read() == true)
                {
                    Student_Uni wr = new Student_Uni();
                    wr.setID(data.GetString("STUD_ID"));
                    wr.setName(data.GetString("STUD_Name"));
                    wr.setClass(data.GetString("STUD_CLU_ID"));
                    wr.setBOD(data.GetString("STUD_BOD"));
                    wr.setSex(data.GetString("STUD_Sex"));
                    wr.setAddress(data.GetString("STUD_Address"));
                    wr.setPhone(data.GetString("STUD_Phone"));
                    wr.setMail(data.GetString("STUD_Mail"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //
        public static List<Student_Uni> FindStudentHS(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Student_Uni> list = new List<Student_Uni>();
                while (data.Read() == true)
                {
                    Student_Uni wr = new Student_Uni();
                    wr.setID(data.GetString("STUD_ID"));
                    wr.setName(data.GetString("STUD_Name"));
                    wr.setClass(data.GetString("STUD_CLHS_ID"));
                    wr.setBOD(data.GetString("STUD_BOD"));
                    wr.setSex(data.GetString("STUD_Sex"));
                    wr.setAddress(data.GetString("STUD_Address"));
                    wr.setPhone(data.GetString("STUD_Phone"));
                    wr.setMail(data.GetString("STUD_Mail"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //insert studen_Uni
        public static Boolean InsertStudent(string admin, string name,string classid,string bod,string sex,string address,string phone,string mail)
        {
            string query = "call myclassroombiden.sp_insertStudent('" + admin + "', '" + name + "','"+classid+"','"+bod+"','"+sex+"','"+address+"','"+phone+"','"+mail+"');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //update student
        public static Boolean UpdateStudent(string admin,string id, string name, string classid, string bod, string sex, string address, string phone, string mail)
        {
            string query = "call myclassroombiden.sp_updateStudent('" + admin + "','"+id+"', '" + name + "','" + classid + "','" + bod + "','" + sex + "','" + address + "','" + phone + "','" + mail + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //delete student
        public static Boolean DeleteStudent(string admin, string id)
        {
            string query = "call myclassroombiden.sp_deleteStudent('" + admin + "','" + id + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //insert subject
        public static string InsertSubject(Monhoc m)
        {
            string result = "";
            
                string user = m.getUser();
                string name = m.getName();
                string mm = m.getMamon();
                string query = "call myclassroombiden.sp_ins_updSubject('" + user + "', '" + mm + "','" + name + "');";
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
        //delete subject
        public static Boolean DeleteSubject(string query)
        {
            try
            {
                using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
                {
                    connec.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connec);
                    cmd.ExecuteNonQuery();
                    connec.Close();
                    
                }
            }
            catch(Exception e)
            {
                e.Message.ToString();
            }
            return false;

        }
        //loadsubject
        public static List<Subject> FindSubject(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Subject> list = new List<Subject>();
                while (data.Read() == true)
                {
                    Subject wr = new Subject();
                    wr.setID(data.GetString("SJ_ID"));
                    wr.setName(data.GetString("SJ_Name"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //load class_subject
        public static List<Class_Subject> FindClassSubject(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Class_Subject> list = new List<Class_Subject>();
                while (data.Read() == true)
                {
                    Class_Subject wr = new Class_Subject();
                    wr.setMalop(data.GetString("CBS_ID"));
                    wr.setMagv(data.GetString("CBS_Tchr_ID"));
                    wr.setMamon(data.GetString("CBS_SJ_ID"));
                    wr.setHocki(data.GetInt32("CBS_Semester"));
                    wr.setNamhoc(data.GetString("CBS_Year"));
                    wr.setSobuoi(data.GetInt32("CBS_Studies"));
                    list.Add(wr);
                }
                return list;
            }
        }
        public static string InsertClassSubject(string malop,string admin ,string magv, string mamon,int hocki,string namhoc,int buoi)
        {
            string result = "";
            string query = "call myclassroombiden.sp_ins_updClass_by_Sub('" + malop + "', '"+admin+"','" + magv + "','" + mamon + "','"+hocki+"','"+namhoc+"','"+buoi+"');";
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
        public static Boolean DeleteClassSubject(string admin, string malop)
        {
            string query = "call myclassroombiden.sp_deleteClass_by_Sub('" + admin + "', '" + malop + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //load Student By Sub
        public static List<Student_Class_Uni> FindStudentClassSubject(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Student_Class_Uni> list = new List<Student_Class_Uni>();
                while (data.Read() == true)
                {
                    Student_Class_Uni wr = new Student_Class_Uni();
                    wr.setId(data.GetString("SIC_STUD_ID"));
                    wr.setName(data.GetString("SIC_STUD_Name"));
                    wr.seLop(data.GetString("SIC_CBS_ID"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //insert Student_class_uni
        public static Boolean InsertStudentClassSubject(string admin, string masv, string malop)
        { 
            string query = "call myclassroombiden.sp_insertStudInClassBySub_uni('" + admin + "', '" + masv + "','"+malop+"');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                if(cmd.ExecuteNonQuery()==1)
                {
                    return true;
                }
                return false;
            }
        }
        //delete student_class_uni
        public static Boolean DeleteStudentClassSubject(string admin, string masv, string malop)
        {
            string query = "call myclassroombiden.sp_deleteStudInClassBySub_uni('" + admin + "', '" + masv + "','" + malop + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //check phân quyền
        public static Account FindID(string id)
        {
            string query = "select * from teacher_login where Tchr_ID='" + id + "'";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    Account teacher = new Account();
                    teacher.setID(data.GetString("STT"));
                    teacher.setUser(data.GetString("Tchr_ID"));
                    teacher.setAdmin(data.GetInt32("isAdmin"));
                    teacher.setType(data.GetInt32("Tchr_Type"));

                    return teacher;
                }
                return null;
            }
        }
        //load Student By Sub
        public static List<Student_Class_Uni> FindStudentClassSubject_Hs(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Student_Class_Uni> list = new List<Student_Class_Uni>();
                while (data.Read() == true)
                {
                    Student_Class_Uni wr = new Student_Class_Uni();
                    wr.setId(data.GetString("SIC_STUD_ID"));
                    wr.setName(data.GetString("SIC_STUD_Name"));
                    wr.seLop(data.GetString("SIC_CBS_ID"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //insert Student_class_hs
        public static string InsertStudentClassSubject_Hs(string admin, string masv, string malop)
        {
            string result = "";
            string query = "call sp_insertStudInClassBySub_hs('" + admin + "', '" + masv + "','" + malop + "');";
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
        //delete student_class_hs
        public static Boolean DeleteStudentClassSubject_Hs(string admin, string masv, string malop)
        {
            string query = "call myclassroombiden.sp_deleteStudInClassBySub_hs('" + admin + "', '" + masv + "','" + malop + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //
        public static List<Study> LoadStudy(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Study> list = new List<Study>();
                while (data.Read() == true)
                {
                    Study wr = new Study();
                    wr.setBuoi(data.GetString("ID"));
                    wr.setBatdau(data.GetString("Time_Begin"));
                    wr.setKetthuc(data.GetString("Time_End"));
                    wr.setNgay(data.GetString("Date_Study"));
                    wr.setMagv(data.GetString("Tchr_ID"));
                    wr.setMamon(data.GetString("CBS_ID"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //
        public static Boolean InsertStudy(string buoi, string batdau, string ketthuc,string ngay,string magv,string mamon)
        {
            string query = "call myclassroombiden.sp_ins_updStudy('" + buoi + "', '" + batdau + "','" + ketthuc + "','"+ngay+"','"+magv+"','"+mamon+"');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //
        public static List<Roll> LoadRollCall(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Roll> list = new List<Roll>();
                while (data.Read() == true)
                {
                    Roll wr = new Roll();
                    wr.setMasv(data.GetString("SSU_STUD_ID"));
                    wr.setName(data.GetString("SSU_STUD_Name"));
                    wr.setLop(data.GetString("SSU_CBS_ID"));
                    wr.setBuoi(data.GetString("SSU_ID"));
                    wr.setGio(data.GetString("Time_In"));
                    wr.setNgay(data.GetString("SSU_Date"));
                    wr.setStatus(data.GetString("Roll_call"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //
        public static List<Roll> LoadRollCallHS(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<Roll> list = new List<Roll>();
                while (data.Read() == true)
                {
                    Roll wr = new Roll();
                    wr.setMasv(data.GetString("SSHS_STUD_ID"));
                    wr.setName(data.GetString("SSHS_STUD_Name"));
                    wr.setLop(data.GetString("SSHS_CBS_ID"));
                    wr.setBuoi(data.GetString("SSHS_ID"));
                    wr.setGio(data.GetString("Time_In"));
                    wr.setNgay(data.GetString("SSHS_Date"));
                    wr.setStatus(data.GetString("Roll_call"));
                    list.Add(wr);
                }
                return list;
            }
        }
        //
        public static Boolean DiemDanh(string magv, string masv, string malop, string status)
        {
            string query = "call myclassroombiden.sp_ins_updAttendance_uni('" + magv + "', '" + masv + "','" + malop + "','" + status + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //
        public static Boolean DiemDanhHS(string magv, string masv, string malop, string status)
        {
            string query = "call myclassroombiden.sp_ins_updAttendance_hs('" + magv + "', '" + masv + "','" + malop + "','" + status + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //
        public static Boolean DeleteBuoi(string admin, string buoi, string malop)
        {
            string query = "call myclassroombiden.sp_deleteStudy('" + admin + "', '" + buoi + "','" + malop + "');";
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        //
        public static List<DetailHS> LoadDetailMarkHS(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<DetailHS> list = new List<DetailHS>();
                while (data.Read() == true)
                {
                    DetailHS wr = new DetailHS();
                    wr.setID(data.GetString("DMHS_ID"));
                    wr.setMaSV(data.GetString("DMHS_STUD_ID"));
                    wr.setMamon(data.GetString("DMHS_CBS_ID"));
                    wr.setLoai(data.GetString("DMHS_Type"));
                    wr.setMark(data.GetString("DMHS_Mark"));
                    wr.setHocki(data.GetString("DMHS_Semester"));         
                    list.Add(wr);
                }
                return list;
            }
        }

        public static List<DetailHS> LoadDetailMarkUni(string query)
        {
            using (MySqlConnection connec = new MySqlConnection(KetNoi.connection))
            {
                connec.Open();
                MySqlCommand cmd = new MySqlCommand(query, connec);
                MySqlDataReader data = cmd.ExecuteReader();
                List<DetailHS> list = new List<DetailHS>();
                while (data.Read() == true)
                {
                    DetailHS wr = new DetailHS();
                    wr.setID(data.GetString("DMU_ID"));
                    wr.setMaSV(data.GetString("DMU_STUD_ID"));
                    wr.setMamon(data.GetString("DMU_CBS_ID"));
                    wr.setLoai(data.GetString("DMU_Type"));
                    wr.setMark(data.GetString("DMU_Mark"));
                   
                    list.Add(wr);
                }
                return list;
            }
        }
    }
}
