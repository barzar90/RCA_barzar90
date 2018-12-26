using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;

namespace RCA.Site.Common
{
    public partial class ViewCR : System.Web.UI.Page
    {
        #region declaration of variables
        BL.BL MAHAITDBAccess;
        String SearchText = String.Empty;
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SearchText"] != null)
                {
                    SearchText = Convert.ToString(Request.QueryString["SearchText"]);
                    BindCRGrid();
                }
            }
            if (MAHAITDBAccess.LangID.ToString() == "1")
            {
                txtKeyword.CDACDestinationLanguage = TextBoxServerControl.TextBoxControl.CDACSupportedLanguages.ENGLISH;
            }
            else
            {
                txtKeyword.CDACDestinationLanguage = TextBoxServerControl.TextBoxControl.CDACSupportedLanguages.MARATHI;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblCRHeading.Text = GetResourceValue("Login", "lblCRHeading", lblCRHeading.Text).ToString();
            lblFromDate.Text = GetResourceValue("Login", "lblFromDate", lblFromDate.Text).ToString();
            lblToDate.Text = GetResourceValue("Login", "lblToDate", lblToDate.Text).ToString();
            lblBranchDesk.Text = GetResourceValue("Login", "lblBranchDesk", lblBranchDesk.Text).ToString();
            lblKeywords.Text = GetResourceValue("Login", "lblKeywords", lblKeywords.Text).ToString();
            lblArchives.Text = GetResourceValue("Login", "lblArchives", lblArchives.Text).ToString();
            btnSearch.Text = GetResourceValue("Login", "btnSearch", btnSearch.Text).ToString();
            btnReset.Text = GetResourceValue("Login", "btnReset", btnReset.Text).ToString();

            if (hdncult.Value == String.Empty)
            {
                hdncult.Value = MAHAITDBAccess.LangID;
                LoadDesk(hdncult.Value);
                LoadArchivesRadioList(hdncult.Value);
                lblNoRecord.Text = "";
            }
            else
            {
                if (MAHAITDBAccess.LangID.ToString() != hdncult.Value)
                {
                    hdncult.Value = MAHAITDBAccess.LangID.ToString();
                    LoadDesk(hdncult.Value);
                    LoadArchivesRadioList(hdncult.Value);
                    lblNoRecord.Text = "";
                }
            }
        }

        private void LoadArchivesRadioList(string langid)
        {
            switch (langid)
            {
                case "1":
                    rblArchives.Items.Add(new ListItem("Current", "1"));
                    rblArchives.Items.Add(new ListItem("Archives", "2"));
                    break;
                case "2":
                    rblArchives.Items.Add(new ListItem("जारी", "1"));
                    rblArchives.Items.Add(new ListItem("संग्रहित", "2"));
                    break;
            }
            rblArchives.SelectedValue = "1";
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        private void LoadDesk(string LangID)
        {
            DataTable t_DT = new DataTable();

            if (ddlDesk.Items.Count > 0)
            {
                ddlDesk.Items.Clear();
            }

            DataTable t_Return = new DataTable();

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select * From mst_Desk where LangID = @LangID Order By Desk";

            t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
            t_SQLCmd.Parameters["@LangID"].Value = LangID;

            t_DT = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd).Tables[0];

            ddlDesk.DataTextField = "Desk";
            ddlDesk.DataValueField = "DeskID";
            ddlDesk.DataSource = t_DT;
            ddlDesk.DataBind();
            if (LangID == "1")
            {
                ddlDesk.Items.Insert(0, "---Select---");
            }
            else
            {
                ddlDesk.Items.Insert(0, "---निवडा---");
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchText = String.Empty;
            BindCRGrid();
        }

        private void BindCRGrid()
        {
            int langid;
            string description = string.Empty;
            string desk = string.Empty;

            if (MAHAITDBAccess.LangID.ToString() == "1")
            {
                langid = 1;
            }
            else
            {
                langid = 2;
            }
            if (ddlDesk.SelectedIndex > 0)
            {
                desk = ddlDesk.SelectedValue;
            }
            description = txtKeyword.Text.Trim();

            DateTime FromDate = DateTime.Now;
            DateTime ToDate = DateTime.Now;
            Boolean DateSearch = true;


            if (txtFromDate.Text != String.Empty && txtToDate.Text != String.Empty)
            {
                DateTime.TryParse(txtFromDate.Text.Trim(), out FromDate);
                DateTime.TryParse(txtToDate.Text.Trim(), out ToDate);
                DateSearch = true;
                if (FromDate > ToDate)
                {
                    if (hdncult.Value == "1")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('From date should not be greater than To date.');", true);
                        return;
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('दिनांकापासून ची तारीख ही दिनांकापर्यंत च्या तारखेपेक्षा पुढची नसली पाहिजे.');", true);
                        return;
                    }
                }
            }
            else
            {
                FromDate = DateTime.Now;
                ToDate = DateTime.Now;
                DateSearch = false;
            }

            DataTable dtCRList = new DataTable();
            dtCRList = FetchCRList(langid, desk, description, FromDate, ToDate, DateSearch);
            if (dtCRList != null)
            {
                if (dtCRList.Rows.Count > 0)
                {
                    NoRecords.Visible = false;
                    lblNoRecord.Text = "";
                    grdCRList.DataSource = dtCRList;
                    switch (MAHAITDBAccess.LangID.ToString())
                    {
                        case "1":
                            grdCRList.Columns[0].HeaderText = "Sr.No.";
                            grdCRList.Columns[2].HeaderText = "Desk";
                            grdCRList.Columns[3].HeaderText = "Title";
                            grdCRList.Columns[5].HeaderText = "Description";
                            grdCRList.Columns[7].HeaderText = "Issue Date";
                            grdCRList.Columns[8].HeaderText = "CR No";
                            grdCRList.Columns[9].HeaderText = "View/Download";
                            break;
                        case "2":
                            grdCRList.Columns[0].HeaderText = "अ.क्र.";
                            grdCRList.Columns[2].HeaderText = "कक्ष";
                            grdCRList.Columns[4].HeaderText = "शीर्षक";
                            grdCRList.Columns[6].HeaderText = "वर्णन";
                            grdCRList.Columns[7].HeaderText = "निर्गमित झाल्याची तारीख";
                            grdCRList.Columns[8].HeaderText = "परिपत्रक क्र.";
                            grdCRList.Columns[9].HeaderText = "पाहा/डाऊनलोड करा";
                            break;
                    }
                }
                else
                {
                    NoRecords.Visible = true;
                    grdCRList.DataSource = null;
                    if (hdncult.Value == "1")
                    {
                        lblNoRecord.Text = "No Records Found";
                    }
                    else
                    {
                        lblNoRecord.Text = "माहिती उपलब्ध नाही.";
                    }
                }
            }
            else
            {
                NoRecords.Visible = true;
                grdCRList.DataSource = null;
                if (hdncult.Value == "1")
                {
                    lblNoRecord.Text = "No Records Found";
                }
                else
                {
                    lblNoRecord.Text = "माहिती उपलब्ध नाही.";
                }
            }
            grdCRList.DataBind();
        }

        private DataTable FetchCRList(int langid, string Desk, string Desc, DateTime FromDate, DateTime ToDate, bool DateSearch)
        {
            DataTable dtList = new DataTable();
            string sqlQuery;
            SqlCommand cmdCR = new SqlCommand();
            try
            {
                sqlQuery = "select A.*, C.Desk as DeskName ";
                sqlQuery += " from MOLUploadFile A INNER JOIN MOLFileCategory B ON B.FileTypeValue=A.Category and B.LangID=A.LangID ";
                sqlQuery += " INNER JOIN Mst_Desk C ON C.DeskID=A.Desk and C.LangID=A.LangID ";
                sqlQuery += " WHERE B.FileTypeValue=2 AND A.Desk=ISNULL(@Desk,A.Desk) AND A.LangID=@LangID ";
                if (langid == 1)
                {
                    sqlQuery += " AND (FileDtl like '%' + @Desc + '%' OR @Desc IS NULL) ";
                }
                else
                {
                    sqlQuery += " AND (FileDtl_LL like '%' + @Desc + '%' OR @Desc IS NULL) ";
                }

                sqlQuery += " AND ((Convert(Date, Date) Between @FromDate and @ToDate) or (@FromDate is null or @ToDate is null))";
                sqlQuery += " AND A.ApprovalStatus = 1 AND A.Archives = @Archives";
                sqlQuery += " ORDER BY A.CreatedOn";

                cmdCR.CommandText = sqlQuery;
                cmdCR.Parameters.Add("@LangID", SqlDbType.Int);
                cmdCR.Parameters["@LangID"].Value = langid;
                cmdCR.Parameters.Add("@Desk", SqlDbType.VarChar);
                if (Desk != "")
                {
                    cmdCR.Parameters["@Desk"].Value = Desk;
                }
                else
                {
                    cmdCR.Parameters["@Desk"].Value = DBNull.Value;
                }
                cmdCR.Parameters.Add("@Desc", SqlDbType.NVarChar);
                if (SearchText == String.Empty)
                {
                    if (Desc != "")
                    {
                        cmdCR.Parameters["@Desc"].Value = Desc;
                    }
                    else
                    {
                        cmdCR.Parameters["@Desc"].Value = DBNull.Value;
                    }
                }
                else
                {
                    cmdCR.Parameters["@Desc"].Value = SearchText;
                }
                cmdCR.Parameters.Add("@FromDate", SqlDbType.DateTime);
                cmdCR.Parameters.Add("@ToDate", SqlDbType.DateTime);
                if (DateSearch)
                {
                    cmdCR.Parameters["@FromDate"].Value = FromDate.ToString("dd MMM yyyy");
                    cmdCR.Parameters["@ToDate"].Value = ToDate.ToString("dd MMM yyyy");
                }
                else
                {
                    cmdCR.Parameters["@FromDate"].Value = DBNull.Value;
                    cmdCR.Parameters["@ToDate"].Value = DBNull.Value;
                }
                cmdCR.Parameters.Add("@Archives", SqlDbType.Bit);
                if (rblArchives.SelectedValue == "1")
                {
                    cmdCR.Parameters["@Archives"].Value = 0;
                }
                else
                {
                    cmdCR.Parameters["@Archives"].Value = 1;
                }
                dtList = MAHAITDBAccess.ExecuteDataSet(cmdCR).Tables[0];

                return dtList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                dtList = null;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);
            lblNoRecord.Text = "";
        }

        private void ClearInputs(ControlCollection controlCollection)
        {
            foreach (Control ctrl in controlCollection)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).ClearSelection();
                }
                else if (ctrl is GridView)
                {
                    ((GridView)ctrl).DataSource = null;
                    ((GridView)ctrl).DataBind();
                }
                ClearInputs(ctrl.Controls);
            }
        }

        protected void grdCRList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCRList.PageIndex = e.NewPageIndex;
            BindCRGrid();
        }

        protected void grdCRList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewFile")
            {
                string RowID = e.CommandArgument.ToString();
                DownLoadFile(RowID);
            }
        }

        private void DownLoadFile(string RowID)
        {
            DataTable dtDownload = new DataTable();
            SqlCommand cmdDownload = new SqlCommand();
            cmdDownload.CommandText = "Select * from MOLUploadFile where RowID=@RowID";
            cmdDownload.Parameters.Add("@RowID", SqlDbType.Int);
            cmdDownload.Parameters["@RowID"].Value = RowID;
            dtDownload = MAHAITDBAccess.ExecuteDataSet(cmdDownload).Tables[0];
            if (dtDownload != null)
            {
                if (dtDownload.Rows.Count > 0)
                {
                    try
                    {
                        string FileType = dtDownload.Rows[0]["FileType"].ToString();
                        Response.Buffer = false;
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.ContentType = dtDownload.Rows[0]["FileType"].ToString();
                        Response.AddHeader("Content-Disposition", "attachment; ");

                        const int chunkSize = 1024;
                        byte[] buffer = new byte[chunkSize];
                        byte[] binary = (dtDownload.Rows[0]["FileContent"]) as byte[];
                        MemoryStream ms = new MemoryStream(binary);
                        int SizeToWrite = chunkSize;

                        for (int i = 0; i < binary.GetUpperBound(0) - 1; i = i + chunkSize)
                        {
                            if (!Response.IsClientConnected) return;
                            if (i + chunkSize >= binary.Length)
                            {
                                SizeToWrite = binary.Length - i;
                            }
                            byte[] chunk = new byte[SizeToWrite];
                            ms.Read(chunk, 0, SizeToWrite);
                            Response.BinaryWrite(chunk);
                            Response.Flush();
                        }
                        Response.Close();

                    }
                    catch (Exception ex)
                    {
                    }

                }
            }
        }

        protected void grdCRList_DataBound(object sender, EventArgs e)
        {
            switch (MAHAITDBAccess.LangID.ToString())
            {
                case "1":
                    grdCRList.Columns[3].Visible = true;
                    grdCRList.Columns[4].Visible = false;
                    grdCRList.Columns[5].Visible = true;
                    grdCRList.Columns[6].Visible = false;
                    break;
                case "2":
                    grdCRList.Columns[3].Visible = false;
                    grdCRList.Columns[4].Visible = true;
                    grdCRList.Columns[5].Visible = false;
                    grdCRList.Columns[6].Visible = true;
                    break;
            }
        }
    }
}