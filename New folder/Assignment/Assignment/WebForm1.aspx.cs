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


            int i = blobj.InsertEmployee(daobj);
            //if (EmpName != null && UserName != null && Password != null && ConfirmPassword != null && Gender != null && PhoneNumber != null && Emailid != null && Designation != null)
            

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

            DataTable dt = blobj.Displaydetails();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GetEmpid(e);
            int i = blobj.Delete(daobj);
         
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
        private void GetEmpid(GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView2.Rows[e.RowIndex];
            Label lbleid = (Label)row.FindControl("lblempid");
            int empid = Convert.ToInt32(lblempid.Text);
            daobj.Empid = empid;
        }

    }
}