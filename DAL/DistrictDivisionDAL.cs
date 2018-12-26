using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;
using Schema;


namespace DAL
{
    public class DistrictDivisionDAL
    {

        public DataSet GetDivisionList()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "sp_GetDivisions"))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetDistrictList(DistrictDivisionSchema objdistrictdivisionchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@DivisionId", SqlDbType.Char);
                param[0].Value = objdistrictdivisionchema.DivisionId;
                
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "sp_GetDistrictList", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
    }
}
