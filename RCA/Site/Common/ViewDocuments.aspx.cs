using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace MOLFrameWork.Site.Common
{
    public partial class ViewDocuments : System.Web.UI.Page
    {
        public int LangID = 0;
      
        string doctype, strdoctype;
        BL MOLDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        private int CurrentPage;
        int _firstIndex, _lastIndex;
        private int _pageSize = 8;
        readonly PagedDataSource _pgsource = new PagedDataSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Doctype"].ToString() != null)
            {
                doctype = Request.QueryString["Doctype"].ToString();
                strdoctype = doctype.Replace("'", "");
            }           
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                LangID = 2;
            else
                LangID = 1;

            DisplayHeading();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            MOLUserControl _molUC = new MOLUserControl();                    
            btnSearch.Text = _molUC.GetResourceValue("General", "Search_btn", "").ToString();
            btnClear.Text = _molUC.GetResourceValue("General", "btnClear", "").ToString();
            lblFromDate.Text = _molUC.GetResourceValue("General", "lblFromDate", "").ToString();
            lblToDate.Text = _molUC.GetResourceValue("General", "lblToDate", "").ToString();
            lblKeywordsearch.Text = _molUC.GetResourceValue("General", "lblKeywordsearch", "").ToString();
            if (!IsPostBack)
                BindRepeater();
        }

        public void BindRepeater()
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

                if (TxtDocNM.Text != string.Empty)
                {
                    if (LangID == 1)
                        strWhere += " and D.Title like '%" + TxtDocNM.Text + "%'";
                    else
                        strWhere += " and D.Title_LL like N'%" + TxtDocNM.Text + "%'";
                }

                //if (DDlCategory.SelectedIndex > 0 && DDlCategory.SelectedValue != "")
                //{
                //    if (LangID.ToString() == "1")
                //    {
                //        sqlQuery = "Select  D.Title As Title, D.Documentpath As DocumentPath,D.Description As Description,D.DocumentType As DocumentType ,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate,D.Size As Size,E.Enumerationvalue As Enumerationvalue " +
                //                  "from tblDocumentMaster D,enumerationValue E  where D.IsDelete=1 and e.EnumerationValueID=D.DocumentType and  " +
                //                  " DocumentType='" + strdoctype.ToString() + "' " + strWhere + " order by cast(CreatedDate as datetime) desc";
                //    }
                //    else
                //    {
                //        sqlQuery = "Select D.Title_LL As Title,D.Documentpath_LL As DocumentPath,D.Description_LL As Description,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate,D.Size As Size,E.Enumerationvalue_LL As Enumerationvalue" +
                //                   " from tblDocumentMaster D,enumerationValue E  where D.IsDelete=1 and e.EnumerationValueID=D.DocumentType and  " +
                //                   " DocumentType='" + strdoctype.ToString() + "' " + strWhere + " order by cast(CreatedDate as datetime) desc";

                //    }
                //}
                //else
                //{
                    if (LangID == 1)
                    {
                        sqlQuery = " Select D.IsActive,D.Title As Title,D.Documentpath As DocumentPath,D.Description As Description,D.DocumentType As DocumentType ,CONVERT(varchar(10), D.CreatedDate ,103) as CreatedDate," +
                                   " D.Size As Size, D.DocumentImage as DocumentImage, E.Enumerationvalue As Enumerationvalue  from tblDocumentMaster D,enumerationValue E " +
                                   " where D.DocumentType = e.EnumerationValueID " + strWhere + " and d.IsDelete=1 AND E.EnumerationValueID in (select EnumerationValueID from EnumerationValue where  parent_EnumerationValueID='" + doctype + "' or EnumerationValueID='" + doctype + "') order by cast(CreatedDate as datetime) desc";
                    }
                    else
                    {
                        sqlQuery = "Select D.Title_LL As Title,D.Documentpath_LL As DocumentPath,D.Description As Description,CONVERT(varchar(20), D.CreatedDate ,103) as CreatedDate," + "D.Size As Size, D.DocumentImage as DocumentImage, E.Enumerationvalue_LL As Enumerationvalue from tblDocumentMaster D,enumerationValue E " +  "where D.DocumentType = e.EnumerationValueID and d.IsDelete=1  " + strWhere + "  AND E.EnumerationValueID in (select EnumerationValueID from EnumerationValue where parent_EnumerationValueID='" + doctype + "' or EnumerationValueID='" + doctype + "')   order by cast(CreatedDate as datetime) desc";
                    }
                //}

                cmd.CommandText = sqlQuery;
                DataTable dtrptr = new DataTable();
                dtrptr = MOLDBAccess.ExecuteDataSet(cmd).Tables[0];
                if (dtrptr != null)
                {
                    _pgsource.DataSource = dtrptr.DefaultView;
                    _pgsource.AllowPaging = true;
                    _pgsource.CurrentPageIndex = CurrentPage;
                    ViewState["TotalPages"] = _pgsource.PageCount;
                    lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
                    lbPrevious.Enabled = !_pgsource.IsFirstPage;
                    lbNext.Enabled = !_pgsource.IsLastPage;
                    lbFirst.Enabled = !_pgsource.IsFirstPage;
                    lbLast.Enabled = !_pgsource.IsLastPage;


                    Repeater1.DataSource = _pgsource;
                    Repeater1.DataBind();

                    HandlePaging();
                    lblmsg.Visible = false;
                }
                else
                {
                    lblmsg.Visible = true;
                    Repeater1.DataSource = null;
                    Repeater1.DataBind();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindRepeater();
        }

        private void HandlePaging()
        {
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            // Check last page is greater than total page then reduced it 
            // to total no. of page is last index
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // Now creating page number based on above first and last page index
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 0;
            BindRepeater();
        }
        protected void lbLast_Click(object sender, EventArgs e)
        {
            CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
            BindRepeater();
        }
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindRepeater();
        }
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindRepeater();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindRepeater();
        }

        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            lnkPage.Enabled = false;
            lnkPage.BackColor = Color.FromName("#00FF00");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
            TxtDocNM.Text = "";
            BindRepeater();
        }

        protected void DisplayHeading()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("SELECT EnumerationValue,EnumerationValue_LL from EnumerationValue where EnumerationID='9A34215A-0129-4787-9B59-B6D8558AA7B4' AND EnumerationValueID=@EnumerationValueID");
                cmd.Parameters.Add("@EnumerationValueID", SqlDbType.UniqueIdentifier);
                Guid EId = new Guid(strdoctype);
                cmd.Parameters[0].Value = EId;
                ds = MOLDBAccess.ExecuteDataSet(cmd);
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
    }
}