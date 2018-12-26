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
    public partial class ViewTenders : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            lblTendersHeading.Text = GetResourceValue("Login", "lblTendersHeading", lblTendersHeading.Text).ToString();
            lblFromDate.Text = GetResourceValue("Login", "lblClosingDate", lblFromDate.Text).ToString();
            lblKeywords.Text = GetResourceValue("Login", "lblKeywords", lblKeywords.Text).ToString();
            btnSearch.Text = GetResourceValue("Login", "btnSearch", btnSearch.Text).ToString();
            btnReset.Text = GetResourceValue("Login", "btnReset", btnReset.Text).ToString();

            if (hdncult.Value == String.Empty)
            {
                hdncult.Value = MAHAITDBAccess.LangID;
                LoadArchivesRadioList(hdncult.Value);
                lblNoRecord.Text = "";
            }
            else
            {
                if (MAHAITDBAccess.LangID.ToString() != hdncult.Value)
                {
                    hdncult.Value = MAHAITDBAccess.LangID.ToString();
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

        private void BindTendersGrid()
        {
            int langid;
            string description = string.Empty;

            if (MAHAITDBAccess.LangID.ToString() == "1")
            {
                langid = 1;
            }
            else
            {
                langid = 2;
            }

            description = txtKeyword.Text.Trim();

            DateTime ClosingDate = DateTime.Now;
            Boolean DateSearch = true;


            if (txtClosingDate.Text != String.Empty)
            {
                DateTime.TryParse(txtClosingDate.Text.Trim(), out ClosingDate);
                DateSearch = true;
            }
            else
            {
                ClosingDate = DateTime.Now;
                DateSearch = false;
            }

            DataTable dtTendersList = new DataTable();
            dtTendersList = FetchTendersList(langid, description, ClosingDate, DateSearch);
            if (dtTendersList != null)
            {
                if (dtTendersList.Rows.Count > 0)
                {
                    NoRecords.Visible = false;
                    lblNoRecord.Text = "";
                    grdTendersList.DataSource = dtTendersList;
                    switch (MAHAITDBAccess.LangID.ToString())
                    {
                        case "1":
                            grdTendersList.Columns[0].HeaderText = "Sr.No.";
                            grdTendersList.Columns[2].HeaderText = "Tender No";
                            grdTendersList.Columns[3].HeaderText = "Description";
                            grdTendersList.Columns[5].HeaderText = "Closing Date";
                            grdTendersList.Columns[6].HeaderText = "View/Download";
                            break;
                        case "2":
                            grdTendersList.Columns[0].HeaderText = "अ.क्र.";
                            grdTendersList.Columns[2].HeaderText = "निविदा क्र.";
                            grdTendersList.Columns[4].HeaderText = "वर्णन";
                            grdTendersList.Columns[5].HeaderText = "बंद होण्याची तारीख";
                            grdTendersList.Columns[6].HeaderText = "पाहा/डाऊनलोड करा";
                            break;
                    }

                }
                else
                {
                    NoRecords.Visible = true;
                    grdTendersList.DataSource = null;
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
                grdTendersList.DataSource = null;
                if (hdncult.Value == "1")
                {
                    lblNoRecord.Text = "No Records Found";
                }
                else
                {
                    lblNoRecord.Text = "माहिती उपलब्ध नाही.";
                }
            }
            grdTendersList.DataBind();
        }

        private DataTable FetchTendersList(int langid, string Desc, DateTime ClosingDate, bool DateSearch)
        {
            DataTable dtList = new DataTable();
            string sqlQuery;
            SqlCommand cmdTenders = new SqlCommand();
            try
            {
                sqlQuery = "select A.* from MOLUploadFile A INNER JOIN MOLFileCategory B ON B.FileTypeValue=A.Category and B.LangID=A.LangID ";
                sqlQuery += " WHERE B.FileTypeValue=9  AND A.LangID=@LangID ";
                if (langid == 1)
                {
                    sqlQuery += " AND (FileDtl like '%' + @Desc + '%' OR @Desc IS NULL) ";
                }
                else
                {
                    sqlQuery += " AND (FileDtl_LL like '%' + @Desc + '%' OR @Desc IS NULL) ";
                }
                sqlQuery += " AND ((Convert(Date, SubDate)= @ClosingDate) or (@ClosingDate is null))";
                sqlQuery += " AND A.ApprovalStatus = 1 AND A.Archives = @Archives ";
                sqlQuery += " ORDER BY A.CreatedOn";

                cmdTenders.CommandText = sqlQuery;
                cmdTenders.Parameters.Add("@LangID", SqlDbType.Int);
                cmdTenders.Parameters["@LangID"].Value = langid;
                cmdTenders.Parameters.Add("@Desc", SqlDbType.NVarChar);
                if (Desc != "")
                {
                    cmdTenders.Parameters["@Desc"].Value = Desc;
                }
                else
                {
                    cmdTenders.Parameters["@Desc"].Value = DBNull.Value;
                }
                cmdTenders.Parameters.Add("@ClosingDate", SqlDbType.DateTime);
                if (DateSearch)
                {
                    cmdTenders.Parameters["@ClosingDate"].Value = ClosingDate.ToString("dd MMM yyyy");
                }
                else
                {
                    cmdTenders.Parameters["@ClosingDate"].Value = DBNull.Value;
                }
                cmdTenders.Parameters.Add("@Archives", SqlDbType.Bit);
                if (rblArchives.SelectedValue == "1")
                {
                    cmdTenders.Parameters["@Archives"].Value = 0;
                }
                else
                {
                    cmdTenders.Parameters["@Archives"].Value = 1;
                }
                dtList = MAHAITDBAccess.ExecuteDataSet(cmdTenders).Tables[0];

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindTendersGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);
            lblNoRecord.Text = "";
        }

        protected void grdTendersList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTendersList.PageIndex = e.NewPageIndex;
            BindTendersGrid();
        }

        protected void grdTendersList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewFile")
            {
                string RowID = e.CommandArgument.ToString();
                DownLoadFile(RowID);
            }
        }

        protected void grdTendersList_DataBound(object sender, EventArgs e)
        {
            switch (MAHAITDBAccess.LangID.ToString())
            {
                case "1":
                    grdTendersList.Columns[3].Visible = true;
                    grdTendersList.Columns[4].Visible = false;
                    break;
                case "2":
                    grdTendersList.Columns[3].Visible = false;
                    grdTendersList.Columns[4].Visible = true;
                    break;
            }
        }
    }
}