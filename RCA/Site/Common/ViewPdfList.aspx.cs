using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BL;

namespace RCA.Site.Common
{
    public partial class ViewPdfList : System.Web.UI.Page
    {
        public int LangID = 0;
        DataSet ds;
        string doctype, strdoctype, doctype1,SessionArchiveValue;
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Doctype"].ToString() != null)
            {
                doctype = Request.QueryString["Doctype"].ToString();
                strdoctype = doctype.Replace("'", "");
                 
            }
            checkArchive();
            
       }





        protected void Page_PreRender(object sender, EventArgs e)
        {

            MAHAITUserControl _mahaITUC = new MAHAITUserControl();
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                LangID = 2;
            else
                LangID = 1;

            grdupload.Columns[0].HeaderText = _mahaITUC.GetResourceValue("General", "lblsrno", "").ToString();
            grdupload.Columns[1].HeaderText = _mahaITUC.GetResourceValue("General", "lbldocNo", "").ToString();
            grdupload.Columns[2].HeaderText = _mahaITUC.GetResourceValue("General", "lblsubject", "").ToString();
            grdupload.Columns[3].HeaderText = _mahaITUC.GetResourceValue("General", "lblDocumentType", "").ToString();
            grdupload.Columns[4].HeaderText = _mahaITUC.GetResourceValue("General", "lbldate", "").ToString();
            grdupload.Columns[5].HeaderText = _mahaITUC.GetResourceValue("General", "lblSize", "").ToString();
            grdupload.Columns[6].HeaderText = _mahaITUC.GetResourceValue("General", "lbldonload", "").ToString();
            btnSearch.Text = _mahaITUC.GetResourceValue("General", "Search_btn", "").ToString();
            btnClear.Text = _mahaITUC.GetResourceValue("General", "btnClear", "").ToString();
            lblFromDate.Text = _mahaITUC.GetResourceValue("General", "lblFromDate", "").ToString();
            lblToDate.Text = _mahaITUC.GetResourceValue("General", "lblToDate", "").ToString();
            lblKeywordsearch.Text = _mahaITUC.GetResourceValue("General", "lblKeywordsearch", "").ToString();
            lblDocumentType.Text = _mahaITUC.GetResourceValue("General", "lblDocumentType", "").ToString();
            btn_Archive.Text = _mahaITUC.GetResourceValue("General", "btn_Archive", "").ToString();
          

            if (!IsPostBack)
            {
                BindDDL("0", LangID);
            }
          

            GridBind();
            Session["doctype"] = doctype;

            if (ViewState["PreviousCulture"] != null)
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() != Convert.ToString(ViewState["PreviousCulture"].ToString()).ToLower())
                {
                    BindDDL(Convert.ToString(DDlCategory.SelectedValue), LangID);
                    GridBind();
                    DisplayHeading();
                }
            ViewState["PreviousCulture"] = System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower();
            DisplayHeading();
        }

        public void checkArchive()
        {
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Select D.Flag,D.DocumentNO As DocumentNO,D.DocumentPath As DocumentPath,D.subject As subject,D.DocumentType As DocumentType ,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate," +
                                   " D.Size As Size,E.Enumerationvalue As Enumerationvalue  from Documents D,enumerationValue E " +
                                   " where D.DocumentType = e.EnumerationValueID  and D.IsArchive=1 and d.Flag=1 AND E.EnumerationValueID in (select EnumerationValueID from EnumerationValue where  parent_EnumerationValueID='" + doctype + "' or EnumerationValueID='" + doctype + "') order by cast(CreatedDate as datetime) desc");
             ds = MAHAITDBAccess.ExecuteDataSet(cmd);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 btn_Archive.Visible = true;
             }
             else
             {
                 btn_Archive.Visible = false;
             }
        }

        public void GridBind()
        {
            string sqlQuery = string.Empty;
            try
            {
                string colname = string.Empty;
                SqlCommand cmd = new SqlCommand();
              
                string strWhere = string.Empty;
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    DateTime d1 = Convert.ToDateTime(txtFromDate.Text);
                    DateTime d2 = Convert.ToDateTime(txtToDate.Text);
                    strWhere = " and CONVERT(varchar(10),CreatedDate,120) between '" + d1.ToString("yyyy-MM-dd") + "' and '" + d2.ToString("yyyy-MM-dd") + "' ";
                }

                doctype1 = TxtDocNM.Text;
                if (doctype1.Contains("'"))
                {
                    Response.Redirect("~/App_Error.aspx");
                }
                if (TxtDocNM.Text != string.Empty)
                {
                    if (LangID.ToString() == "1")
                        strWhere += " and D.subject like '%" + TxtDocNM.Text + "%'";
                    else
                        strWhere += " and D.subject_LL like N'%" + TxtDocNM.Text + "%'";
                }

                if (DDlCategory.SelectedIndex > 0 && DDlCategory.SelectedValue != "" )
                {
                    if (LangID.ToString() == "1")
                    {
                        sqlQuery = "Select  D.DocumentNO As DocumentNO,D.DocumentPath As DocumentPath,D.subject As subject,D.DocumentType As DocumentType ,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate,D.Size As Size,E.Enumerationvalue As Enumerationvalue " +
                                  "from Documents D,enumerationValue E  where D.IsArchive=0 and D.Flag=1 and e.EnumerationValueID=D.DocumentType and  " +
                                  " DocumentType='" + DDlCategory.SelectedValue.ToString() + "' " + strWhere + " order by cast(CreatedDate as datetime) desc";
                    }
                    else
                    {
                        sqlQuery = "Select D.DocumentNO_LL As DocumentNO,D.DocumentPath_LL As DocumentPath,D.subject_LL As subject,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate,D.Size As Size,E.Enumerationvalue_LL As Enumerationvalue" +
                                   " from Documents D,enumerationValue E  where D.IsArchive=0 and D.Flag=1 and e.EnumerationValueID=D.DocumentType and  " +
                                   " DocumentType='" + DDlCategory.SelectedValue.ToString() + "' " + strWhere + " order by cast(CreatedDate as datetime) desc";

                    }
                }
                else
                {
                    if (LangID == 1)
                    {
                        sqlQuery = " Select D.Flag,D.DocumentNO As DocumentNO,D.DocumentPath As DocumentPath,D.subject As subject,D.DocumentType As DocumentType ,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate," +
                                   " D.Size As Size,E.Enumerationvalue As Enumerationvalue  from Documents D,enumerationValue E " +
                                   " where D.DocumentType = e.EnumerationValueID " + strWhere + " and D.IsArchive=0 and d.Flag=1 AND E.EnumerationValueID in (select EnumerationValueID from EnumerationValue where  parent_EnumerationValueID='" + doctype + "' or EnumerationValueID='" + doctype + "') order by cast(CreatedDate as datetime) desc";
                    }
                    else
                    {
                        sqlQuery = "Select D.DocumentNO_LL As DocumentNO,D.DocumentPath_LL As DocumentPath,D.subject_LL As subject,CONVERT(varchar(20), D.CreatedDate ,103) as CreatedDate," +
                                   "D.Size As Size,E.Enumerationvalue_LL As Enumerationvalue from Documents D,enumerationValue E " +
                                    "where D.DocumentType = e.EnumerationValueID and D.IsArchive=0 and d.Flag=1  " + strWhere + "  AND E.EnumerationValueID in (select EnumerationValueID from EnumerationValue where parent_EnumerationValueID='" + doctype + "' or EnumerationValueID='" + doctype + "')   order by cast(CreatedDate as datetime) desc";
                    }
                }

                cmd.CommandText = sqlQuery;
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    grdupload.DataSource = ds.Tables[0];
                    grdupload.DataBind();
                    lblmsg.Visible = false;
                }
                else
                {
                    lblmsg.Visible = true;
                    grdupload.DataSource = null;
                    grdupload.DataBind();
                }
            }
            catch (Exception ex) { }
        }

        protected void DisplayHeading()
        {
            try
            {

                ds = new DataSet();
                SqlCommand cmd = new SqlCommand("SELECT EnumerationValue,EnumerationValue_LL from EnumerationValue where EnumerationID='9A34215A-0129-4787-9B59-B6D8558AA7B4' AND EnumerationValueID=@EnumerationValueID");
                cmd.Parameters.Add("@EnumerationValueID", SqlDbType.UniqueIdentifier);
                Guid EId = new Guid(strdoctype);
                cmd.Parameters[0].Value = EId;
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LangID == 1)
                        LblDynamicotherpdf.Text = ds.Tables[0].Rows[0]["EnumerationValue"].ToString();
                    else
                        LblDynamicotherpdf.Text = ds.Tables[0].Rows[0]["EnumerationValue_LL"].ToString();

                }
            }
            catch (Exception ex) { }
            finally { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void BindDDL(string SelectedValue, int LangID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = null;
                ds = null;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select EnumerationValueID,Enumerationvalue ,Enumerationvalue_LL from enumerationValue where EnumerationId='9A34215A-0129-4787-9B59-B6D8558AA7B4' and parent_EnumerationValueID='" + doctype + "' and IsActive=1 " +
                    "select EnumerationValueID,Enumerationvalue ,Enumerationvalue_LL from enumerationValue where EnumerationId='9A34215A-0129-4787-9B59-B6D8558AA7B4' and EnumerationValueID='" + doctype + "' and IsActive=1 ";
                Guid EId = new Guid(doctype);
                cmd.Parameters.Add("@parent_EnumerationValueID", SqlDbType.UniqueIdentifier);
                cmd.Parameters[0].Value = EId;
                ds = MAHAITDBAccess.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    dt = ds.Tables[0];
                else if (ds != null && ds.Tables[1].Rows.Count > 0)
                    dt = ds.Tables[1];
                if (dt.Rows.Count > 0)
                {
                    DDlCategory.DataSource = dt;
                    DDlCategory.DataValueField = "EnumerationValueID";

                    if (LangID.ToString() == "1")
                    {
                        DDlCategory.DataTextField = "Enumerationvalue";
                        DDlCategory.DataBind();
                        DDlCategory.Items.Insert(0, "ALL");
                        DDlCategory.SelectedValue = doctype;
                    }
                    else
                    {
                        DDlCategory.DataTextField = "Enumerationvalue_LL";
                        DDlCategory.DataBind();
                        DDlCategory.Items.Insert(0, "सर्व");
                        DDlCategory.SelectedValue = doctype;
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { ds = null; }
        }

        protected void grdupload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdupload.EditIndex = -1;
            grdupload.PageIndex = e.NewPageIndex;
            GridBind();
            grdupload.DataBind();
        }

        protected void DDlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDlCategory.SelectedIndex > 0)
                GridBind();

        }

        protected void btn_Archive_Click(object sender, EventArgs e)
        {
            try
            {
                string archiveValue = Session["doctype"].ToString();
                Response.Redirect("ViewArchivePdfList.aspx?ArchiveValue=" + archiveValue);
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}