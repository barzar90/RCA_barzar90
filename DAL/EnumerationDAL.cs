using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Schema;
using Helper;

namespace DAL
{
    public class EnumerationDAL
    {
        #region Declaration of Variable

        SqlConnection objConn;
        DataSet ds;
        SqlTransaction objTran;
        string sqlQuery;
        #endregion

        #region Get Enumeration Values of those with Maharashtra Government Standards
        public DataSet GetEnumerationValuesMAH(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') order by sortorder";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Get Enumeration Values of those with SQL Standards
        public DataSet GetEnumerationValuesSQL(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();

                int Langid = Convert.ToInt32(objEnumerationSchema.LangID);
                if (Langid == 1)
                {

                    sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') and LangID=1 order by SortOrder";

                }
                else if (Langid == 2)
                {

                    sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') and LangID=1 order by SortOrder";
                }
                // sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') order by SortOrder";


                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }




        public DataSet GetEnumerationValuesSQL_AllPDF(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                int Langid = Convert.ToInt32(objEnumerationSchema.LangID);
                if (Langid == 1)
                {

                    sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') and LangID=1 order by SortOrder";

                }
                else
                {
                    sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') and LangID=1 order by SortOrder";

                    //sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') and LangID=2 order by SortOrder";
                }


                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        public DataSet GetEnumerationValuesSQLForFactoryType(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = " select  EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "' and SortOrder not in (1)) and  EnumerationValueID <> 'CD61C7DE-E8AD-4129-9EE7-27FAA03E66C8' order by SortOrder ";
                //   sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "') order by SortOrder";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }

        public DataSet GetEnumerationValuesSQL1(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "' and EnumerationValueID not in('6374ACDD-9434-4792-838E-1C06E4530685')) order by SortOrder";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Get Enumeration Values of those with SQL Standards
        public DataSet GetEnumerationValuesSQLForSelectedDDP(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select EnumerationValueID,EnumerationValue from EnumerationValue where enumerationID in (select enumerationID from enumeration where enumerationname='" + objEnumerationSchema.EnumerationName + "')";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Insert Enumeration Values of those with SQL Standards
        public void GetEnumerationInsertPageEnumerationvalue(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();

                objTran = objConn.BeginTransaction();


                string str = "insert into EnumerationValue (EnumerationID,EnumerationValue,IsDefault,SortOrder,IsActive) values (CAST ('" + objEnumerationSchema.EnumerationID + "' as uniqueidentifier),'" + objEnumerationSchema.EnumerationValue + "','True','1','true')";
                int returnval = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.Text, str);
                objTran.Commit();
            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Get Enumeration Values of those with SQL Standards
        public DataTable GetValuesfromEnumerationDuplicateValuesCheck(EnumerationSchema objEnumerationSchema)
        {
            DataTable dt;
            try
            {
                dt = new DataTable();
                objConn = SQLHelper.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("select EnumerationID from Enumeration where EnumerationName='" + objEnumerationSchema.EnumerationName + "'", objConn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex) { return dt = null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                dt = null;
            }
        }
        #endregion

        #region Get Enumeration Values after the insert query of those with SQL Standards
        public DataSet GetValuesfromEnumeration()
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "Select EnumerationName,IsActive,EnumerationID from Enumeration";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Get Enumeration Values after the insert query of those with SQL Standards
        public DataSet GetEnumerationValueswithwerecondition(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select EnumerationID,EnumerationName from Enumeration where EnumerationID='" + objEnumerationSchema.EnumerationName + "'";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Insert Enumeration Values of those with SQL Standards
        public void GetEnumerationInsert(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("insert into Enumeration (EnumerationName,IsActive) values (@EnumerationName,@IsActive)", objConn);
                cmd.Parameters.Add("@EnumerationName", SqlDbType.VarChar);
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit);

                cmd.Parameters[0].Value = objEnumerationSchema.EnumerationName;
                cmd.Parameters[1].Value = "True";

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Update Enumeration Values of those with SQL Standards
        public void GetEnumerationUpdate(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                //objConn = SQLHelper.OpenConnection();
                //SqlCommand cmd = new SqlCommand("update  Enumeration set EnumerationName=@EnumerationName where EnumerationID=@EnumerationID", objConn);

                //cmd.Parameters.Add("@EnumerationName", SqlDbType.VarChar);
                //cmd.Parameters.Add("@EnumerationID", SqlDbType.UniqueIdentifier);

                //cmd.Parameters[0].Value = objEnumerationSchema.EnumerationName;
                //cmd.Parameters[1].Value = objEnumerationSchema.EnumerationID;

                //cmd.ExecuteNonQuery();



                objConn = SQLHelper.OpenConnection();

                objTran = objConn.BeginTransaction();


                string str = "update  Enumeration set EnumerationName='" + objEnumerationSchema.EnumerationName + "'  where EnumerationID='" + objEnumerationSchema.EnumerationID + "'";
                int returnval = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.Text, str);
                objTran.Commit();

            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion
      
        public DataSet GetEnumerationvalueMaster()
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select EnumerationID,EnumerationName from Enumeration ";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        public DataSet GetEnumerationvalueGridValue()
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select *  from EnumerationValue";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
     
        #region Insert into ProjectProfile values
        public void InsertIntoLandAcquisitiondetails(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();

                objTran = objConn.BeginTransaction();


                // string str = "insert into EnumerationValue (EnumerationID,EnumerationValue,IsDefault,SortOrder,IsActive) values (CAST ('" + objEnumerationSchema.EnumerationID + "' as uniqueidentifier),'" + objEnumerationSchema.EnumerationValue + "')";
                //string str = "insert into EnumerationValue (EnumerationID,EnumerationValue,IsDefault,SortOrder,IsActive) values ('" + objEnumerationSchema.VillageId + ",'" + objEnumerationSchema.SlaoId + ",'" + objEnumerationSchema.AwardNo + ",'" + objEnumerationSchema.NatureOfAcquisition + ",'" + objEnumerationSchema.LandAcquisitionDeatilsPapId + ",'" + objEnumerationSchema.GatNos + ",'" + objEnumerationSchema.Areaasper712 + ",'" + objEnumerationSchema.AreaAsPerJMS + ",'" + objEnumerationSchema.AreaAcquired + ",'" + objEnumerationSchema.CompensationAmountPayable + ",'" + objEnumerationSchema.CompensationAmountPayable + ",'" + objEnumerationSchema.DateOfPayment + "')";
                //int returnval = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.Text, str);
                //objTran.Commit();
            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region Get season Values of those with SQL Standards
        public DataSet GetSeasonValuesSQL()
        {
            try
            {


                objConn = SQLHelper.OpenConnection();
                sqlQuery = "select SeasonID ,Season  from Season order by SeasonID desc";
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, sqlQuery);
                return ds;
            }
            catch (Exception ex) { return null; }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        public void InsertIntoPapcertificateDetails(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();

                objTran = objConn.BeginTransaction();



            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        // #endregion
        // Uptill here

        #region Insert Enumeration Values of those with SQL Standards
        public void InsertInto(EnumerationSchema objEnumerationSchema)
        {
            try
            {

                objConn = SQLHelper.OpenConnection();
                SqlCommand cmd = new SqlCommand("insert into EmployeeMaster (EmployeeName,) values (@EmployeeName,@IsActive)", objConn);
                cmd.Parameters.Add("@EnumerationName", SqlDbType.VarChar);
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit);

                cmd.Parameters[0].Value = objEnumerationSchema.EnumerationName;
                cmd.Parameters[1].Value = "True";

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { }
            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }
        #endregion

        #region "Insert Division Form Values Into Employee Master and User Master Table"

        public int GetEnumerationInsertIntoEmp(EmployeeSchema objEnumerationSchema)
        {
            int result = 0;

            try
            {
                objConn = SQLHelper.OpenConnection();

                 return 1;
            }

            catch (Exception ex)
            {
                return 0;
            }

            finally
            {
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
            return result;
        }
        #endregion
    }
}
