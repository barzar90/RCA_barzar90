using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Data;

namespace RCA.Admin.MenuManagement
{
    public partial class CaseList : System.Web.UI.Page
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
            if (!Page.IsPostBack) { BindGrid(); }
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            btnCaseEntry.Text = _MahaITUC.GetResourceValue("Resource", "btnCaseEntry", "Case Entry");
            
        }

        protected void btnCaseEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/CaseEntryForm.aspx");
        }

        private void BindGrid()
        {
            try
            {
                string strExpr = null;
                objCaseDetailSchema.ActionType = "BindGrid";
                objCaseDetailSchema.CaseID = 0;
                objCaseDetailSchema.CaseNo = string.Empty;
                ds = objCaseDetailBL.GetCaseListDetails(objCaseDetailSchema);
                dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    grdCaseList.DataSource = dt.DefaultView;
                    grdCaseList.DataBind();
                }
                else
                {
                    grdCaseList.DataSource = null;
                    grdCaseList.DataBind();
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

        public String GetSiteURL()
        {
            return Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty);
        }

        protected void grdCaseList_delete(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void grdCaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCaseList.PageIndex = e.NewPageIndex;
            grdCaseList.DataBind();
            BindGrid();
        }

        protected void grdCaseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    string[] commandArgs =(e.CommandArgument).ToString().Split(new char[] {','});
                    objCaseDetailSchema.CaseID = Convert.ToInt32(commandArgs[0]);
                    objCaseDetailSchema.CaseNo = commandArgs[1];
                    objCaseDetailSchema.ActionType = "MainCase";

                    int result = objCaseDetailBL.DeleteCaseDetails(objCaseDetailSchema);
                    if (result > 0)
                    {
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Menu deleted Succesfully !!!')", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Alert", "alert('Menu deleted Succesfully !!!')", true);
                        BindGrid();
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
    }
}