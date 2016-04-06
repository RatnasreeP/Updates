using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BusinessAccessLayer;
using DataAccessLayer;


namespace Assignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        BlEmployee blobj = new BlEmployee();
        DaEmployee daobj=new DaEmployee();
    

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnsave.Text == "save")
                {
                    InsertintoDb();
                    int i = blobj.InsertEmployee(daobj);
                    if(i>0)
                    {
                       Response.Write("inserted successfully");
                    }
                    //if (EmpName != null && UserName != null && Password != null && ConfirmPassword != null && Gender != null && PhoneNumber != null && Emailid != null && Designation != null)
                }
                if (btnsave.Text == "Update")
                {
                    InsertintoDb();
                    int i = blobj.Updateedit(daobj);
                }
            }
            catch(Exception ex)
            {

            }

        }

        private void InsertintoDb()
        {

            daobj.EmpName = txtEmpName.Text;
            daobj.UserName = txtUserName.Text;
            daobj.Password = txtPassword.Text;
            daobj.ConfirmPassword = txtConfirmPassword.Text;
            daobj.Gender = null;
            daobj.PhoneNumber = txtPhoneNumber.Text;
            daobj.Emailid = txtEmailId.Text;
            daobj.Designation = ddlDesignation1.SelectedItem.Value.ToString();
            daobj.Empid = Convert.ToInt32(txtlblempid.Text);

            if (rbMale.Checked == true)
            {
                daobj.Gender = rbMale.Text;
            }
            else
            {
                daobj.Gender = rbFeMale.Text;
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmpName.Text = "";
            txtUserName.Text="";
            txtPassword.Text="";
            txtConfirmPassword.Text="";
            rbFeMale.Checked = false;
            rbMale.Checked = false;
            txtPhoneNumber.Text="";
            txtEmailId.Text="";
            ddlDesignation1.ClearSelection();
            txtlblempid = null;
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
               BindData();

        }
        public void BindData()
        {

            SqlDataReader dr = blobj.Displaydetails();
            GridView2.DataSource = dr;
            GridView2.DataBind();
            GridView2.Visible = true;
            dr.Close();
        }

      

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "edt")
                {
                    GridView2.Visible = false;
                    btnsave.Text = "Update";
                    
                    int empid = Convert.ToInt32(e.CommandArgument.ToString());
                    daobj.Empid = empid;
                    DataTable dt = new DataTable();

                    SqlDataReader dr = blobj.EditEmployeeDetails(daobj);


                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtEmpName.Text = dr[0].ToString();
                            txtUserName.Text = dr[1].ToString();
                            if (daobj.Gender=="Male")
                            {
                                rbMale.Checked=true;
                            }
                            else
                            {
                                rbFeMale.Checked=true;
                            }
                            txtPhoneNumber.Text = dr[5].ToString();
                            txtEmailId.Text = dr[6].ToString();
                            txtlblempid.Text = dr[8].ToString();
                            txtlblempid.ReadOnly = true;
                        }
                        dr.Close();


                    }

                }
                if (e.CommandName == "delete")
                {
                    //GridViewRow row = GridView2.SelectedRow;
                    //int empid = Convert.ToInt32(row.Cells(6).Text);
                    int empid = Convert.ToInt32(e.CommandArgument.ToString());
                    daobj.Empid = empid;
                    int i = blobj.Delete(daobj);
                }
            }
            catch(Exception EX)
            {
                Response.Write(EX.Message+""+EX.StackTrace);
            }
        }

        protected void btnsave_Click1(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click2(object sender, EventArgs e)
        {

        }
        //public void GetDetails()
        //{
          
        //}

    }
}