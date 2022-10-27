using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal;

namespace dallibrary
{
    public class DAL
    { 
        public bool Insert(BAL school)
        {
            
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdInsert = new SqlCommand("insert into student(student_id,student_name) values(@student_id,@student_name)", cn);
            cmdInsert.Parameters.AddWithValue("@student_id", school.student_id);
            cmdInsert.Parameters.AddWithValue("@student_name", school.student_name);


            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();
            cn.Dispose();
            return status;



        }

        public bool Update(BAL school)
        {

            
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatestudent]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_stuid", school.student_id);
            cmdUpdate.Parameters.AddWithValue("@p_stuname", school.student_name);
            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();
            cn.Dispose();
            return statusd;

        }
        public BAL Find(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findstudent", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_stuid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_name";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            BAL found = new BAL();

            found.student_name = p1.Value.ToString();

            cn.Close();
            cn.Dispose();


            return found;

        }
        public List<BAL> List()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");


            SqlCommand cmdlist = new SqlCommand("select student_id,student_name from student", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.student_id = Convert.ToInt32(dr["student_id"]);
                    bal.student_name = dr["student_name"].ToString();
                    

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Delete(int stuid)
        {
            //      SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletestudent", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return status;

        }
        public List<BAL> List1()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");


            SqlCommand cmdlist = new SqlCommand("select subjects_id,subjects_name from subjects", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.subjects_id = Convert.ToInt32(dr["subjects_id"]);
                    bal.subjects_name = dr["subjects_name"].ToString();
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Insert1(BAL school)
        {
            //  SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdInsert = new SqlCommand("insert into subjects(subjects_id,subjects_name) values(@subjects_id,@subjects_name)", cn);
            cmdInsert.Parameters.AddWithValue("@subjects_id", school.subjects_id);
            cmdInsert.Parameters.AddWithValue("@subjects_name", school.subjects_name);


            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }

        public bool Update1(BAL school)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updatesubjects]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_subid", school.subjects_id);
            cmdUpdate.Parameters.AddWithValue("@p_subname", school.subjects_name);

            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();//finally
            cn.Dispose();//finally
            return statusd;

        }
        public BAL Find1(int id)
        {
            //  SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthCnString"].ConnectionString);
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findsubjects", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_subid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_subname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);







            cn.Open();
            cmdSelect.ExecuteNonQuery();

            BAL found = new BAL();

            found.subjects_name = p1.Value.ToString();





            cn.Close();
            cn.Dispose();


            return found;



        }
        public bool Delete1(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deletesubjects", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public List<BAL> List2()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");


            SqlCommand cmdlist = new SqlCommand("select * from class", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.class_roomno = Convert.ToInt32(dr["class_roomno"]);
                    bal.class_strength = dr["class_strength"].ToString();
                    //   bal.student_class = Convert.ToInt32(dr["student_class"]);

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool Insert2(BAL school)
        {            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdInsert = new SqlCommand("insert into classes(class_roomno,class_strength) values(@class_roomno,@class_strength)", cn);
            cmdInsert.Parameters.AddWithValue("@class_roomno", school.class_roomno);
            cmdInsert.Parameters.AddWithValue("@class_strength", school.class_strength);


            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();

            bool status = false;

            if (i == 1)
            {
                status = true;
            }

            cn.Close();//finally
            cn.Dispose();//finally
            return status;



        }

        public bool Update2(BAL school)
        {

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdUpdate = new SqlCommand("[dbo].[Updateclass]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_classroomno", school.class_roomno);
            cmdUpdate.Parameters.AddWithValue("@p_class_stre", school.class_strength);
            cn.Open();
            int s = cmdUpdate.ExecuteNonQuery();
            bool statusd = false;
            if (s == 1)
            {
                statusd = true;
            }
            cn.Close();
            cn.Dispose();
            return statusd;

        }
        public BAL Find2(int id)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_Findclass", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_classid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_class_st";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 10;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            BAL found = new BAL();

            found.class_strength = p1.Value.ToString();
           
            cn.Close();
            cn.Dispose();


            return found;



        }
        public bool Delete2(int stuid)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-974787H\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_Deleteclass", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_id1", stuid);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }

    }
}
