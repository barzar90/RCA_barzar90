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
    public class DistrictDivisionBL
    {
        #region Public variable declaration
        DistrictDivisionDAL objDistrictDivisionDAL = new DistrictDivisionDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetDivisionList()
        {
            try
            {
                ds = objDistrictDivisionDAL.GetDivisionList();
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

        public DataSet GetDistrictList(DistrictDivisionSchema objmenuschema)
        {
            try
            {
                ds = objDistrictDivisionDAL.GetDistrictList(objmenuschema);
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
