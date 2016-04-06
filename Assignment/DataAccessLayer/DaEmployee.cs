using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DaEmployee
    {
        public string EmpName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Emailid { get; set; }
        public string Designation { get; set; }
        public int Empid { get; set; }

        static string connection = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        static SqlConnection con = new SqlConnection(connection); 


        public int InsertEmployee(DaEmployee daobj)
        {
            using (SqlCommand cmd = new SqlCommand("sp_inserrt", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", daobj.EmpName);
                cmd.Parameters.AddWithValue("@UserName", daobj.UserName);
                cmd.Parameters.AddWithValue("@Password", daobj.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", daobj.ConfirmPassword);
                cmd.Parameters.AddWithValue("@Gender", daobj.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", daobj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Emailid", daobj.Emailid);
                cmd.Parameters.AddWithValue("@Designation", daobj.Designation);
                cmd.Parameters.AddWithValue("@Empid", daobj.Empid);

                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }  
            

        }
        //public int UpdateEmployee(DaEmployee daobj)
        //{

        //    return i;
        //}
        public SqlDataReader Displaydetails()
        {
            if (con.State != ConnectionState.Closed)
            con.Close();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_displaytable", con))
            {
               
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    //  con.Close();
                    return dr;
                    // dr.Close();
            }
          
            
        }
        public int Delete(DaEmployee daobj)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            using(SqlCommand cmd = new SqlCommand("sp_delete", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empid", daobj.Empid);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
               
              
            }
         

        }
        public SqlDataReader EditEmployeeDetails(DaEmployee daobj)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
                SqlCommand cmd = new SqlCommand("sp_edit", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empid", daobj.Empid);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
                

        }
        public int Updateedit(DaEmployee daobj)
        {
           // if (con.State != ConnectionState.Closed)
             //   con.Close();
            using (SqlCommand cmd = new SqlCommand("sp_updateedit", con))
            {
              //  con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", daobj.EmpName);
                cmd.Parameters.AddWithValue("@UserName", daobj.UserName);
                cmd.Parameters.AddWithValue("@Password", daobj.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", daobj.ConfirmPassword);
                cmd.Parameters.AddWithValue("@Gender", daobj.Gender);
                cmd.Parameters.AddWithValue("@PhoneNumber", daobj.PhoneNumber);
                cmd.Parameters.AddWithValue("@Emailid", daobj.Emailid);
                cmd.Parameters.AddWithValue("@Designation", daobj.Designation);
                cmd.Parameters.AddWithValue("@Empid", daobj.Empid);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
        }
    
    }
}
