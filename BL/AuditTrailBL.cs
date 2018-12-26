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
    public class AuditTrailBL
    {
        #region Public variable declaration
        AuditTrailDAL objAuditTrailDAL = new AuditTrailDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetAuditTrail()
        {
            try
            {
                ds = objAuditTrailDAL.GetAuditTrail();
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
