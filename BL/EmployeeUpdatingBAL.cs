using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Schema;
using DAL;

namespace BL
{
    public class EmployeeUpdatingBAL
    {
        EmployeeUpdatingDAL objEmployeeUpdatingDAL;
        DataSet ds;

        public bool UpdateEmployee(EmployeeUpdatingSchema objEmployeeUpdatingSchema)
        {
            try
            {
            
                objEmployeeUpdatingDAL = new EmployeeUpdatingDAL();
                ds = objEmployeeUpdatingDAL.GetEmployeeUpdate(objEmployeeUpdatingSchema);
                return true;
            }
            catch (Exception ex) { return false; }
            finally
            {
                ds = null;
            }
        }
    }
}
