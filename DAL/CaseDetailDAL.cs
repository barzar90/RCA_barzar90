using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class CaseDetailDAL
    {
        public int SaveCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                                new SqlParameter("@CaseNo",string.IsNullOrWhiteSpace(objcasedetailschema.CaseNo) ? (object)DBNull.Value : objcasedetailschema.CaseNo),
                                new SqlParameter("@DivisionId",string.IsNullOrWhiteSpace(objcasedetailschema.DivisionId) ? (object)DBNull.Value : objcasedetailschema.DivisionId),
                                new SqlParameter("@DistrictId",string.IsNullOrWhiteSpace(objcasedetailschema.DistrictId) ? (object)DBNull.Value : objcasedetailschema.DistrictId),
                                new SqlParameter("@ApplicantName",string.IsNullOrWhiteSpace(objcasedetailschema.ApplicantName) ? (object)DBNull.Value : objcasedetailschema.ApplicantName),
                                new SqlParameter("@OpponentName",string.IsNullOrWhiteSpace(objcasedetailschema.OpponentName) ? (object)DBNull.Value : objcasedetailschema.OpponentName),
                                new SqlParameter("@CaseStatus",string.IsNullOrWhiteSpace(objcasedetailschema.CaseStatus) ? (object)DBNull.Value : objcasedetailschema.CaseStatus),
                                new SqlParameter("@LastHearingDate",objcasedetailschema.LastHearingDate == null ? (object)DBNull.Value : objcasedetailschema.LastHearingDate),
                                new SqlParameter("@NextHearingDate",objcasedetailschema.NextHearingDate == null ? (object)DBNull.Value : objcasedetailschema.NextHearingDate),
                                new SqlParameter("@CreatedDate",objcasedetailschema.CreatedDate == null ? (object)DBNull.Value : objcasedetailschema.CreatedDate),
                                new SqlParameter("@CreatedBy",objcasedetailschema.CreatedBy == null ? (object)DBNull.Value : objcasedetailschema.CreatedBy),
                                new SqlParameter("@UpdatedBy",objcasedetailschema.UpdatedBy == null ? (object)DBNull.Value : objcasedetailschema.UpdatedBy),
                                new SqlParameter("@UpdatedDate",objcasedetailschema.UpdatedDate == null ? (object)DBNull.Value : objcasedetailschema.UpdatedDate),
                                new SqlParameter("@IsDelete",objcasedetailschema.IsDelete)
                        };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "sp_AddCaseDetails", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {

            }
        }

        public DataSet GetCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[0].Value = objcasedetailschema.ActionType;
                param[1] = new SqlParameter("@ID", SqlDbType.Int);
                param[1].Value = objcasedetailschema.CaseID;
                param[2] = new SqlParameter("@CaseNo", SqlDbType.NVarChar);
                param[2].Value = string.IsNullOrWhiteSpace(objcasedetailschema.CaseNo) ? (object)DBNull.Value : objcasedetailschema.CaseNo;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "sp_GetCaseDetails", param))
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

        public DataSet CheckCaseExist(CaseDetailSchema objcasedetailschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                
                param[0] = new SqlParameter("@CaseNo", SqlDbType.NVarChar);
                param[0].Value = string.IsNullOrWhiteSpace(objcasedetailschema.CaseNo) ? (object)DBNull.Value : objcasedetailschema.CaseNo;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "spCheckCaseNoExist", param))
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

        public int DeleteCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            //var param = new SqlParameter[]
                            //{
                            // new SqlParameter("@Menuid",objmenuschema.Menuid == 0 ? 0 : objmenuschema.Menuid),
                            //};

                            SqlParameter[] param = new SqlParameter[3];

                            param[0] = new SqlParameter("@CaseID", SqlDbType.Int);
                            param[0].Value = objcasedetailschema.CaseID;
                            param[1] = new SqlParameter("@CaseNo", SqlDbType.VarChar);
                            param[1].Value = objcasedetailschema.CaseNo;
                            param[2] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                            param[2].Value = objcasedetailschema.ActionType;

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "spDeleteCaseDetails", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }

        public int UpdateCaseDetails(CaseDetailSchema objcasedetailschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            //var param = new SqlParameter[]
                            //{
                            // new SqlParameter("@Menuid",objmenuschema.Menuid == 0 ? 0 : objmenuschema.Menuid),
                            //};

                            SqlParameter[] param = new SqlParameter[4];

                            param[0] = new SqlParameter("@CaseID", SqlDbType.Int);
                            param[0].Value = objcasedetailschema.CaseID;
                            param[1] = new SqlParameter("@CaseStatus", SqlDbType.NVarChar);
                            param[1].Value = objcasedetailschema.CaseStatus;
                            param[2] = new SqlParameter("@NextHearingDate", SqlDbType.DateTime);
                            param[2].Value = objcasedetailschema.NextHearingDate;
                            param[3] = new SqlParameter("@LastHearingDate", SqlDbType.DateTime);
                            param[3].Value = objcasedetailschema.LastHearingDate;

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "spUpdateCaseDetails", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }

        public DataSet GetCaseTrackDetails(CaseDetailSchema objcasedetailschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[0].Value = objcasedetailschema.ActionType;
                param[1] = new SqlParameter("@CaseNo", SqlDbType.NVarChar);
                param[1].Value = string.IsNullOrWhiteSpace(objcasedetailschema.CaseNo) ? (object)DBNull.Value : objcasedetailschema.CaseNo;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "spGetCaseTracking", param))
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
