using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;

namespace RCA.Site.Home
{
    public partial class CaseTracking : System.Web.UI.Page
    {
        #region Public variable declaration
        int LangID = 0;
        DataSet ds;
        DataTable dt;
        CaseDetailSchema objCaseDetailSchema = new CaseDetailSchema();
        CaseDetailBL objCaseDetailBL = new CaseDetailBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grdCaseList.Visible = false;
                BindGrid();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                Session["LangId"] = LangID;
                if (txtCaseNo.Text == string.Empty)
                {
                    BindGrid();
                }
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                LangID = 1;
                Session["LangId"] = LangID;
                if (txtCaseNo.Text == string.Empty)
                {
                    BindGrid();
                }
            }
            else
            {
                LangID = 3;
                Session["LangId"] = LangID;
                if (txtCaseNo.Text == string.Empty)
                {
                    BindGrid();
                }
            }
            MAHAITUserControl _mahaITUC = new MAHAITUserControl();
            lblCaseNo.Text = _mahaITUC.GetResourceValue("General", "lblCaseNo", "").ToString();
            txtCaseNo.Text = _mahaITUC.GetResourceValue("General", "txtCaseNo", "").ToString();
            btnReset.Text = _mahaITUC.GetResourceValue("General", "btnReset", "").ToString();
            btnSearch.Text = _mahaITUC.GetResourceValue("General", "btnSearch", "").ToString();
            Reset();
        }

        private void Reset()
        {
            txtCaseNo.Text = "";
        }

        protected void grdCaseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCaseList.PageIndex = e.NewPageIndex;

            if (txtCaseNo.Text != "")
                BindGrid();
            else
                BindGridSearch();
        }

        private void BindGrid()
        {
            try
            {
                objCaseDetailSchema.ActionType = "BindCaseTrack";
                objCaseDetailSchema.CaseNo = string.Empty;
                ds = objCaseDetailBL.GetCaseTrackDetails(objCaseDetailSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdCaseList.DataSource = dt;
                    grdCaseList.DataBind();
                    grdCaseList.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCaseNo.Text != string.Empty)
                {
                    BindGridSearch();
                }
                else
                {
                    ShowMessage("Please Enter A KeyWord To Search");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowMessage(string Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('" + Message + "');", true);
        }

        private void BindGridSearch()
        {
            try
            {
                objCaseDetailSchema.ActionType = "Search_Case";
                objCaseDetailSchema.CaseNo = txtCaseNo.Text.Trim();
                ds = objCaseDetailBL.GetCaseTrackDetails(objCaseDetailSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdCaseList.DataSource = dt;
                    grdCaseList.DataBind();
                    grdCaseList.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                objCaseDetailSchema.ActionType = "Search_Case";
                objCaseDetailSchema.CaseNo = txtCaseNo.Text.Trim();
                ds = objCaseDetailBL.GetCaseTrackDetails(objCaseDetailSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdCaseList.DataSource = dt;
                    grdCaseList.DataBind();
                    grdCaseList.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}