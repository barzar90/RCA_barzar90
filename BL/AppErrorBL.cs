using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using DAL;
using System;
using Schema;

namespace BL
{
    public class AppErrorBL
    {
        #region Public variable declaration
        AppErrorDAL objapperrorDAL = new AppErrorDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public int SaveAppErrorDeatails(AppErrorSchema objAppErrorSchema)
        {
            try
            {
                result = objapperrorDAL.SaveAppErrorLog(objAppErrorSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetErrorLogList(AppErrorSchema objAppErrorSchema)
        {
            try
            {
                ds = objapperrorDAL.GetErrorLogList(objAppErrorSchema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
    }
}
