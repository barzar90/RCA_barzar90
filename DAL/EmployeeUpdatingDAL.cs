using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using Schema;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmployeeUpdatingDAL
    {
        #region
        SqlConnection objConn;
        DataSet ds;
        SqlTransaction objTran;
        string sqlQuery;
        #endregion

        public DataSet GetEmployeeUpdate(EmployeeUpdatingSchema objEmployeeUpdatingSchema)
        {

            //  EmployeeID, UserID, EmployeeName, DesignationID, DivisionID
            try
            {
                objConn = SQLHelper.OpenConnection();
                ds = new DataSet();
                string str = "Update  EmployeeMaster set UserID='" + objEmployeeUpdatingSchema.User_ID + "', EmployeeName='" + objEmployeeUpdatingSchema.EmployeeName + "',DesignationID='" + objEmployeeUpdatingSchema.EmployeeDesignation + "',DivisionID='" + objEmployeeUpdatingSchema.EmployeeDivisionName + "', DistrictID='" + objEmployeeUpdatingSchema.Employee_district + "',FactoryID='" + objEmployeeUpdatingSchema.Factory_id + "' where EmployeeID='" + objEmployeeUpdatingSchema.EmployeeID + "'";
                str += "Update usermaster set MobileNo='" + objEmployeeUpdatingSchema.Mobile_No + "',EmailId='" + objEmployeeUpdatingSchema.Email_Id1 + "' where UserID='" + objEmployeeUpdatingSchema.User_ID + "'";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, str);
                objTran.Commit();
                //   SqlDataAdapter da = new SqlDataAdapter(InsertIntoEmp,objConn );
                //   da.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                return null;
            }

            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
                objEmployeeUpdatingSchema = null;
            }
            //return result;
        }
    }
}
