using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Schema;
using Helper;

namespace DAL
{
    public class EventDL
    {

        #region Declaration of Variable

        SqlConnection objConn;
        SqlTransaction objTran;
        string sqlQuery;
        string spName;
        SqlConnection conn;
        DataSet ds;
        int returnVal;
        string connstr = ConfigurationSettings.AppSettings["Local"].ToString();
        #endregion

        public DataSet Read_Values(EventSchema objEventSchema)
        {
            DataSet ds = new DataSet();
            try
            {

                objConn = SQLHelper.OpenConnection();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", objEventSchema.KeyID);
                ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Read_Values_Events", param);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }

            return ds;
        }

        public int Save_Events(EventSchema objEventSchema)
        {
            int retval = 0;
            try
            {

                objConn = SQLHelper.OpenConnection();
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ID", objEventSchema.KeyID);
                param[1] = new SqlParameter("@Event_Heading", objEventSchema.EventHeading);
                param[2] = new SqlParameter("@Is_Active", objEventSchema.Is_Active);
                param[3] = new SqlParameter("@Event_Detail", objEventSchema.Event_Detail_Xml);
                param[4] = new SqlParameter("@Event_Image", objEventSchema.Event_Image_Xml);
                param[5] = new SqlParameter("@Event_Dtls", objEventSchema.Event_Dtls);
                retval = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Save_Events", param);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }

            return retval;
        }
    }
}
