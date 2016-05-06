using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessAccessLayer
{
    public class BlEmployee
    {
        //public string EmpName { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        //public string Gender { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Emailid { get; set; }
        //public string Designation { get; set; }
        //public int Empid { get; set; }

        DaEmployee daobj = new DaEmployee();
        public int InsertEmployee(DaEmployee daobj)
        {
            return daobj.InsertEmployee(daobj);
        }

       public DataTable Displaydetails()
        {

            return daobj.Displaydetails();
        }
        public int Delete(DaEmployee daobj)
       {
           return daobj.Delete(daobj);
       }
    }
}
