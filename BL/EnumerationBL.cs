using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using System.Data;
using DAL;

namespace BL
{


    public class EnumerationBL
    {

        EnumerationDAL objEnumerationDAL;
        DataSet ds;
        DataTable dt;

        public DataSet GetEnumerationMAH(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesMAH(objEnumerationSchema);
                return ds;
            }

            catch (Exception ex) { return null; }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationValuesSQLForSelectedDDPBL(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesSQLForSelectedDDP(objEnumerationSchema);
                return ds;
            }

            catch (Exception ex) { return null; }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumValues(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesSQL(objEnumerationSchema);
                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }

            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumValues_AllPDF(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesSQL_AllPDF(objEnumerationSchema);
                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }

            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumValuesForFactoryType(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesSQLForFactoryType(objEnumerationSchema);
                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }

            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumValues1(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesSQL1(objEnumerationSchema);
                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }

            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetSeasonBAL()
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetSeasonValuesSQL();
                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }

            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationSQL(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValuesMAH(objEnumerationSchema);
                return ds;
            }

            catch (Exception ex) { return null; }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public void GetEnumerationInsertPageEnumerationvalue(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                objEnumerationDAL.GetEnumerationInsertPageEnumerationvalue(objEnumerationSchema);

            }

            catch (Exception ex) { }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public void GetEnumerationInsertIntoEmp(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                objEnumerationDAL.GetEnumerationInsert(objEnumerationSchema);

            }

            catch (Exception ex) { }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationvalueswithwhereclause(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationValueswithwerecondition(objEnumerationSchema);
                return ds;

            }

            catch (Exception ex) { return null; }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public void GetEnumerationUpdate(EnumerationSchema objEnumerationSchema)
        {
            try
            {
                objEnumerationDAL = new EnumerationDAL();
                objEnumerationDAL.GetEnumerationUpdate(objEnumerationSchema);


            }

            catch (Exception ex) { }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationSelect()
        {
            try
            {

                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetValuesfromEnumeration();
                return ds;
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationvalueMaster()
        {
            try
            {

                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationvalueMaster();
                return ds;
            }

            catch (Exception ex)
            {
                return ds = null;
            }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataSet GetEnumerationvalueGrid()
        {
            try
            {

                objEnumerationDAL = new EnumerationDAL();
                ds = objEnumerationDAL.GetEnumerationvalueGridValue();
                return ds;
            }

            catch (Exception ex)
            {
                return ds = null;
            }
            finally
            {
                objEnumerationDAL = null;
                ds = null;
            }
        }

        public DataTable GetEnumerationvalueDuplicatevaluesbl(EnumerationSchema objEnumerationSchema)
        {
            DataTable dt;
            try
            {
                dt = new DataTable();
                objEnumerationDAL = new EnumerationDAL();
                dt = objEnumerationDAL.GetValuesfromEnumerationDuplicateValuesCheck(objEnumerationSchema);
                return dt;

            }

            catch (Exception ex)
            {
                return dt = null;
            }
            finally
            {
                objEnumerationDAL = null;
                dt = null;
            }
        }




    }
}
