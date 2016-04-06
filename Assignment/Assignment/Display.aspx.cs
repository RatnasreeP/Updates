using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Assignment
{
    public partial class Display : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd1 = new SqlCommand("select EmpName,UserName,Gender,PhoneNumber,Emailid,Designation from Employee1110", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
           Label lblen = (Label)row.FindControl("lblemp");
            string empname=lblen.Text;
            SqlCommand cmd = new SqlCommand(" delete Employee1110 where EmpName=@empname", con);
            cmd.Parameters.AddWithValue("@empname", empname);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            BindData();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            BindData();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
          // Label lblen1 = (Label)row.FindControl("lblemp");
           TextBox value = (TextBox)row.FindControl("txtemp");
            string empname = value.Text;
            TextBox txtph = (TextBox)row.FindControl("TextBox1");
            string phnum = txtph.Text;
            TextBox txtumane = (TextBox)row.FindControl("txtusername");
            string uname = txtumane.Text;
            TextBox txtgender = (TextBox)row.FindControl("txtgender");
            string gender = txtgender.Text;
            TextBox txtemail = (TextBox)row.FindControl("txtemailid");
            string emailid = txtemail.Text;
            TextBox txtdesignation1 = (TextBox)row.FindControl("txtdesignation");
            string designation = txtdesignation1.Text;

            GridView1.EditIndex = -1;
            SqlCommand cmd1 = new SqlCommand("update Employee1110 set PhoneNumber=@phnum,UserName=@uname,Gender=@gender,Emailid=@emailid,Designation=@designation where EmpName=@empname", con);
            cmd1.Parameters.AddWithValue("@phnum", phnum);
            cmd1.Parameters.AddWithValue("@uname", uname);
            cmd1.Parameters.AddWithValue("@gender", gender);
            cmd1.Parameters.AddWithValue("@emailid", emailid);
            cmd1.Parameters.AddWithValue("@designation", designation);
            cmd1.Parameters.AddWithValue("@empname", empname);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();

        }

    }
}