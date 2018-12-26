using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using DAL;
using System.Data;

namespace BL
{
    public class CreateEnumerationBL
    {
        CreateEnumerationDL objCreateEnumerationDL;
        DataSet ds;

        public DataSet GetEnumeration()
        {
            ds = new DataSet();
            objCreateEnumerationDL = new CreateEnumerationDL();
            try
            {
                ds = objCreateEnumerationDL.GetEnumeration();
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public DataSet GetEnumerationValues(string EnumerationID)
        {
            ds = new DataSet();
            objCreateEnumerationDL = new CreateEnumerationDL();
            try
            {
                ds = objCreateEnumerationDL.GetEnumerationvalues(EnumerationID);
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }

        public int InsertEnumeration(EnumerationSchema objEnumerationSchema)
        {
            objCreateEnumerationDL = new CreateEnumerationDL();
            return objCreateEnumerationDL.InsertEnumeration(objEnumerationSchema);
        }

    }
}
