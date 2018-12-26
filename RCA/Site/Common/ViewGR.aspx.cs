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
    public partial class ViewGR : System.Web.UI.Page
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
                    BindGRGrid();
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
            lblGRHeading.Text = GetResourceValue("Login", "lblGRHeading", lblGRHeading.Text).ToString();
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
            BindGRGrid();
        }

        private void BindGRGrid()
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

            DataTable dtGRList = new DataTable();
            dtGRList = FetchGRList(langid, desk, description, FromDate, ToDate, DateSearch);
            if (dtGRList != null)
            {
                if (dtGRList.Rows.Count > 0)
                {
                    NoRecords.Visible = false;
                    lblNoRecord.Text = "";
                    grdGRList.DataSource = dtGRList;
                    switch (MAHAITDBAccess.LangID.ToString())
                    {
                        case "1":
                            grdGRList.Columns[0].HeaderText = "Sr.No.";
                            grdGRList.Columns[2].HeaderText = "Branch/Desk";
                            grdGRList.Columns[3].HeaderText = "Title";
                            grdGRList.Columns[5].HeaderText = "Description";
                            grdGRList.Columns[7].HeaderText = "Issue Date";
                            grdGRList.Columns[8].HeaderText = "GR No";
                            grdGRList.Columns[9].HeaderText = "View/Download";
                            break;
                        case "2":
                            grdGRList.Columns[0].HeaderText = "अ.क्र.";
                            grdGRList.Columns[2].HeaderText = "शाखा/कक्ष";
                            grdGRList.Columns[4].HeaderText = "शीर्षक";
                            grdGRList.Columns[6].HeaderText = "वर्णन";
                            grdGRList.Columns[7].HeaderText = "निर्गमित झाल्याची तारीख";
                            grdGRList.Columns[8].HeaderText = "शा.नि. क्र.";
                            grdGRList.Columns[9].HeaderText = "पाहा/डाऊनलोड करा";
                            break;
                    }
                }
                else
                {
                    NoRecords.Visible = true;
                    grdGRList.DataSource = null;
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
                grdGRList.DataSource = null;
                if (hdncult.Value == "1")
                {
                    lblNoRecord.Text = "No Records Found";
                }
                else
                {
                    lblNoRecord.Text = "माहिती उपलब्ध नाही.";
                }
            }
            grdGRList.DataBind();
        }

        private DataTable FetchGRList(int langid, string Desk, string Desc, DateTime FromDate, DateTime ToDate, bool DateSearch)
        {
            DataTable dtList = new DataTable();
            string sqlQuery;
            SqlCommand cmdGR = new SqlCommand();
            try
            {
                sqlQuery = "select A.*, C.Desk as DeskName ";
                sqlQuery += " from MOLUploadFile A INNER JOIN MOLFileCategory B ON B.FileTypeValue=A.Category and B.LangID=A.LangID ";
                sqlQuery += " INNER JOIN Mst_Desk C ON C.DeskID=A.Desk and C.LangID=A.LangID ";
                sqlQuery += " WHERE B.FileTypeValue=1 AND A.Desk=ISNULL(@Desk,A.Desk) AND A.LangID=@LangID ";
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

                cmdGR.CommandText = sqlQuery;
                cmdGR.Parameters.Add("@LangID", SqlDbType.Int);
                cmdGR.Parameters["@LangID"].Value = langid;
                cmdGR.Parameters.Add("@Desk", SqlDbType.VarChar);
                if (Desk != "")
                {
                    cmdGR.Parameters["@Desk"].Value = Desk;
                }
                else
                {
                    cmdGR.Parameters["@Desk"].Value = DBNull.Value;
                }
                cmdGR.Parameters.Add("@Desc", SqlDbType.NVarChar);
                if (SearchText == String.Empty)
                {
                    if (Desc != "")
                    {
                        cmdGR.Parameters["@Desc"].Value = Desc;
                    }
                    else
                    {
                        cmdGR.Parameters["@Desc"].Value = DBNull.Value;
                    }
                }
                else
                {
                    cmdGR.Parameters["@Desc"].Value = SearchText;
                }
                cmdGR.Parameters.Add("@FromDate", SqlDbType.DateTime);
                cmdGR.Parameters.Add("@ToDate", SqlDbType.DateTime);
                if (DateSearch)
                {
                    cmdGR.Parameters["@FromDate"].Value = FromDate.ToString("dd MMM yyyy");
                    cmdGR.Parameters["@ToDate"].Value = ToDate.ToString("dd MMM yyyy");
                }
                else
                {
                    cmdGR.Parameters["@FromDate"].Value = DBNull.Value;
                    cmdGR.Parameters["@ToDate"].Value = DBNull.Value;
                }

                cmdGR.Parameters.Add("@Archives", SqlDbType.Bit);
                if (rblArchives.SelectedValue == "1")
                {
                    cmdGR.Parameters["@Archives"].Value = 0;
                }
                else
                {
                    cmdGR.Parameters["@Archives"].Value = 1;
                }
                dtList = MAHAITDBAccess.ExecuteDataSet(cmdGR).Tables[0];

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

        protected void grdGRList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdGRList.PageIndex = e.NewPageIndex;
            BindGRGrid();
        }

        protected void grdGRList_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void grdGRList_DataBound(object sender, EventArgs e)
        {
            switch (MAHAITDBAccess.LangID.ToString())
            {
                case "1":
                    grdGRList.Columns[3].Visible = true;
                    grdGRList.Columns[4].Visible = false;
                    grdGRList.Columns[5].Visible = true;
                    grdGRList.Columns[6].Visible = false;
                    break;
                case "2":
                    grdGRList.Columns[3].Visible = false;
                    grdGRList.Columns[4].Visible = true;
                    grdGRList.Columns[5].Visible = false;
                    grdGRList.Columns[6].Visible = true;
                    break;
            }
        }



    }
}