using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Schema;
using Helper;

namespace DAL
{
    public class EmployeeDAL
    {
        int _returnValue;
        #region Declaration of Variable

        SqlConnection objConn;
        DataSet ds;
        SqlTransaction objTran;
        string sqlQuery;
        #endregion

        #region "Insert Division Form Values Into Employee Master and User Master Table"

        public int AddEmployee(EmployeeSchema objEmployeeSchema)
        {
            //    DataSet ds1 = new DataSet();
            int i;
            try
            {
                objConn = SQLHelper.OpenConnection();
                string userId = System.Guid.NewGuid().ToString();
                // result = SQLHelper.ExecuteNonQuery(objConn, SQLHelper.m_transaction, CommandType.Text, "");
                // string InsertIntoEmp = "Insert Into EmployeeMaster(EmployeeID, UserID, EmployeeName, DesignationID, DivisionID)values('" + System.Guid.NewGuid() + "','" + userId + "','" + objEmployeeSchema.EmployeeName + "','" + objEmployeeSchema.EmployeeDesignation + "','" + objEmployeeSchema.EmployeeDivisionName + "')";
                //  string InsertUserMaster = "Insert Into UserMaster(UserID, UsertypeID, Username, Password, PasswordChanged, IsActive)values('" + userId + "','" + System.Guid.NewGuid() + "','" + objEmployeeSchema.EmployeeUsername + "','" + objEmployeeSchema.EmployeePassword + "',0,1)";


                string InsertIntoEmp = "Insert Into EmployeeMaster(EmployeeID, UserID, EmployeeName, DesignationID, DivisionID,DistrictID)values('" + System.Guid.NewGuid() + "','" + userId + "','" + objEmployeeSchema.EmployeeName + "','" + objEmployeeSchema.EmployeeDesignation + "','" + objEmployeeSchema.EmployeeDivisionName + "','" + objEmployeeSchema.Employee_district + "')" + "\n ";
                InsertIntoEmp += " Insert Into UserMaster(UserID, UsertypeID, Username, Password, PasswordChanged, IsActive,EmailId,MobileNo)values('" + userId + "','" + objEmployeeSchema.EmployeeType + "','" + objEmployeeSchema.EmployeeUsername + "','" + objEmployeeSchema.EmployeePassword + "',0,1,'" + objEmployeeSchema.Email_Id1 + "',' " + objEmployeeSchema.Mobile_No + "')";

                i = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.Text, InsertIntoEmp);
                //ds1 = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, InsertUserMaster);
                //       objTran.Commit();
                //   SqlDataAdapter da = new SqlDataAdapter(InsertIntoEmp,objConn );
                //   da.Fill(ds);
                return i;
            }



            finally
            {
                SQLHelper.CloseConnection(objConn);

            }
            //return result;
        }
        #endregion
        #region "For Clearing the text of textboxes and dropdown list"
        public void cleartext()
        {
            try
            {
                EmployeeSchema objEmployeeSchema = new EmployeeSchema();
                objEmployeeSchema.EmployeeDesignation = "1";
                objEmployeeSchema.EmployeeDivisionName = "1";
                objEmployeeSchema.EmployeeName = "";
                objEmployeeSchema.EmployeeUsername = "";
                objEmployeeSchema.EmployeePassword = "";
                objEmployeeSchema.EmployeeType = "1";
            }
            catch (Exception ex)
            {

            }

            #endregion

        }

        public DataSet GetEmployees()
        {

            try
            {
                objConn = SQLHelper.OpenConnection();
                sqlQuery = "";
                sqlQuery = " SELECT Desi.EnumerationValue AS Designation,UM.Username ,Div.EnumerationValue As Division,EM.EmployeeName,EM.UserID,EM.EmployeeID,UM.IsActive,UM.EmailId,UM.MobileNo FROM EmployeeMaster EM Inner Join UserMaster UM On EM.UserID = UM.UserID INNER JOIN " +
                            "(" +
                              " SELECT E.EnumerationID,Ev.EnumerationValueID,E.EnumerationName,EV.EnumerationValue " +
                              " FROM Enumeration E INNER JOIN EnumerationValue EV ON E.EnumerationID=EV.EnumerationID" +
                            ") AS Desi " +
                            " ON EM.DesignationID=Desi.EnumerationValueID INNER JOIN " +
                            "(" +
                              " SELECT E.EnumerationID,Ev.EnumerationValueID,E.EnumerationName,EV.EnumerationValue " +
                              " FROM Enumeration E INNER JOIN EnumerationValue EV ON E.EnumerationID=EV.EnumerationID " +
                            ") AS Div " +
                            " ON EM.DivisionID=Div.EnumerationValueID  order by EM.EmployeeName ";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
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
            }
        }

        #region Using Query string to get the records 

        public DataSet GetEmployeeMasterQueryString(string ID)
        {
            try
            {
                objConn = SQLHelper.OpenConnection();
                sqlQuery = "SELECT * FROM EmployeeMaster em INNER JOIN UserMaster um ON em.UserID=um.UserID WHERE em.EmployeeID='" + ID + "'";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
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
            }
        }

        #endregion

        public int DeactivateUser(string UserID, string Status)
        {
            try
            {
                Status = (Status.ToLower() == "deactivate") ? "1" : "0";
                string strSql = " Update UserMaster Set IsActive = '" + Status + "' Where UserID = '" + UserID + "'";
                objConn = SQLHelper.OpenConnection();
                SqlCommand command = new SqlCommand(strSql, objConn, null);
                _returnValue = command.ExecuteNonQuery();
                return _returnValue;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

    }
}
