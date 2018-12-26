using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using DAL;
using System;
using Schema;
using System.Data;

namespace BL
{
    public class CaseDetailBL
    {
        #region Public variable declaration
        CaseDetailDAL objCaseDetailDAL = new CaseDetailDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public int SaveCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                result = objCaseDetailDAL.SaveCaseDetails(objcasedetailschema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetCaseListDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                ds = objCaseDetailDAL.GetCaseDetails(objcasedetailschema);
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
        

        public DataSet CheckIsCaseExist(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                ds = objCaseDetailDAL.CheckCaseExist(objcasedetailschema);
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


        public int DeleteCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                result = objCaseDetailDAL.DeleteCaseDetails(objcasedetailschema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                result = objCaseDetailDAL.UpdateCaseDetails(objcasedetailschema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetCaseTrackDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {
                ds = objCaseDetailDAL.GetCaseTrackDetails(objcasedetailschema);
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
