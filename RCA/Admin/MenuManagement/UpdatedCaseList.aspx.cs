using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Schema;

namespace RCA.Admin.MenuManagement
{
    public partial class UpdatedCaseList : System.Web.UI.Page
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess;
        DataTable dt;
        CaseDetailSchema objCaseDetailSchema = new CaseDetailSchema();
        CaseDetailBL objCaseDetailBL = new CaseDetailBL();
        DataSet ds;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["action"]) == "view" && Request.QueryString["action"] != null) {
                    BindUpdatedCaseGridByID();
                }
                else { BindUpdatedCaseGrid(); }
                   
            }
        }

        public String GetSiteURL()
        {
            return Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty);
        }

        private void BindUpdatedCaseGrid()
        {
            try
            {
                string strExpr = null;
                objCaseDetailSchema.ActionType = "BindUpdatedCaseGrid";
                objCaseDetailSchema.CaseID = 0;
                objCaseDetailSchema.CaseNo = string.Empty;
                ds = objCaseDetailBL.GetCaseListDetails(objCaseDetailSchema);
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    grdUpdatedCaseList.DataSource = dt.DefaultView;
                    grdUpdatedCaseList.DataBind();
                }
                else
                {
                    grdUpdatedCaseList.DataSource = null;
                    grdUpdatedCaseList.DataBind();
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
            }
        }

        private void BindUpdatedCaseGridByID()
        {
            try
            {
                
                objCaseDetailSchema.ActionType = "FetchUpdatedGridByID";
                objCaseDetailSchema.CaseNo = Request.QueryString["CaseNo"];
                objCaseDetailSchema.CaseID = 0;
                ds = objCaseDetailBL.GetCaseListDetails(objCaseDetailSchema);
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    grdUpdatedCaseList.DataSource = dt.DefaultView;
                    grdUpdatedCaseList.DataBind();
                }
                else
                {
                    grdUpdatedCaseList.DataSource = null;
                    grdUpdatedCaseList.DataBind();
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
            }
        }

        protected void grdUpdatedCaseList_delete(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void grdUpdatedCaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUpdatedCaseList.PageIndex = e.NewPageIndex;
            grdUpdatedCaseList.DataBind();
            BindUpdatedCaseGrid();
        }

        protected void grdUpdatedCaseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    string[] commandArgs = (e.CommandArgument).ToString().Split(new char[] { ',' });
                    objCaseDetailSchema.CaseID = Convert.ToInt32(commandArgs[0]);
                    objCaseDetailSchema.CaseNo = commandArgs[1];
                    objCaseDetailSchema.ActionType = "SubCase";

                    int result = objCaseDetailBL.DeleteCaseDetails(objCaseDetailSchema);
                    if (result > 0)
                    {
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Menu deleted Succesfully !!!')", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Menu deleted Succesfully !!!')", true);
                        BindUpdatedCaseGrid();
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Error !!!')", true);
                    }
                }
                catch (Exception ee)
                { throw ee; }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["action"]) == "view" && Request.QueryString["action"] != null)
            {
                Response.Redirect("CaseList.aspx");
            }
            else
            {
                Response.Redirect("CaseList.aspx");
            }
        }
    }
}