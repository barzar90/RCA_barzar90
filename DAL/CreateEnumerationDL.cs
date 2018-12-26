using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Schema;
using Helper;

namespace DAL
{
    public class CreateEnumerationDL
    {

        #region Declaration of Variable

        SqlConnection objConn;
        SqlTransaction objTran;
        string sqlQuery;
        string spName;
        SqlConnection conn;
        DataSet ds;
        int returnVal = 0;
        string connstr = ConfigurationSettings.AppSettings["APPID"].ToString();
        #endregion

        public DataSet GetEnumeration()
        {
            DataSet ds = new DataSet();
            try
            {
                objConn = SQLHelper.OpenConnection();
                SqlParameter[] param = new SqlParameter[0];
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, "select EnumerationValueID,EnumerationValue from EnumerationValue where parent_EnumerationValueID Is NULL and  IsActive = 1", param);
            }
            catch (Exception ex)
            { }
            finally
            { SQLHelper.CloseConnection(objConn); }
            return ds;
        }

        public DataSet GetEnumerationvalues(string EnumerationID)
        {
            DataSet ds = new DataSet();
            try
            {
                string Query = "select ROW_NUMBER() over(order by EnumerationValueID)as ID,EnumerationValueID,EnumerationValue,EnumerationValue_LL,SortOrder,IsActive from EnumerationValue where parent_EnumerationValueID=@parent_EnumerationValueID";

                objConn = SQLHelper.OpenConnection();
                SqlParameter[] cmdParameters = new SqlParameter[1];
                Guid EnumerationValueID = new Guid(EnumerationID.ToUpper());

                cmdParameters[0] = new SqlParameter("@parent_EnumerationValueID", SqlDbType.UniqueIdentifier);
                cmdParameters[0].Value = EnumerationValueID;

                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.Text, Query, cmdParameters);
            }
            catch (Exception ex)
            { }
            finally
            { SQLHelper.CloseConnection(objConn); }
            return ds;
        }

        public int InsertEnumeration(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                conn = SQLHelper.OpenConnection();
                objConn = SQLHelper.OpenConnection();
                string Query = "INSERT INTO EnumerationValue(EnumerationValue,EnumerationID,EnumerationValue_LL,SortOrder,IsActive,EnumerationCode,IsDefault,parent_EnumerationValueID)" +
                             "values(@EnumerationValue,@EnumerationID,@EnumerationValue_LL,@SortOrder,@IsActive,@EnumerationCode,@IsDefault,@parent_EnumerationValueID)";
                SqlParameter[] cmdParameters = new SqlParameter[8];


                cmdParameters[0] = new SqlParameter("@EnumerationValue", SqlDbType.NVarChar);
                cmdParameters[0].Value = objEnumerationSchema.EnumerationValue;
                cmdParameters[1] = new SqlParameter("@EnumerationID", SqlDbType.NVarChar);
                cmdParameters[1].Value = "9A34215A-0129-4787-9B59-B6D8558AA7B4";
                cmdParameters[2] = new SqlParameter("@EnumerationValue_LL", SqlDbType.NVarChar);
                cmdParameters[2].Value = objEnumerationSchema.EnumationValue_LL;
                cmdParameters[3] = new SqlParameter("@SortOrder", SqlDbType.Int);
                cmdParameters[3].Value = objEnumerationSchema.SortOrder;
                cmdParameters[4] = new SqlParameter("@IsActive", SqlDbType.Bit);
                cmdParameters[4].Value = objEnumerationSchema.Isactive;
                cmdParameters[5] = new SqlParameter("@EnumerationCode", SqlDbType.Int);
                cmdParameters[5].Value = 0;
                cmdParameters[6] = new SqlParameter("@IsDefault", SqlDbType.Bit);
                cmdParameters[6].Value = 0;
                cmdParameters[7] = new SqlParameter("@parent_EnumerationValueID", SqlDbType.NVarChar);
                if (objEnumerationSchema.Parent_EnumerationValueID == "0")
                    cmdParameters[7].Value = DBNull.Value;
                else
                    cmdParameters[7].Value = objEnumerationSchema.Parent_EnumerationValueID;

                returnVal = 0;
                returnVal = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.Text, Query, cmdParameters);
            }
            catch (Exception ex) { }
            finally { SQLHelper.CloseConnection(objConn); }
            return returnVal;

        }
    }
}
