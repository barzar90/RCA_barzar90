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

namespace RCA.Site.Home
{
    public partial class News : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                MAHAITDBAccess.LangID = "2";
            }
            else
            {
                MAHAITDBAccess.LangID = "1";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlCommand cmdBanner = new SqlCommand();
                cmdBanner.CommandType = CommandType.Text;
                string langid = MAHAITDBAccess.LangID.ToString();

                string strQuery;
                string newsvar = System.Configuration.ConfigurationManager.AppSettings["NewsCount"].ToString();

                strQuery = "SELECT  A.*, ";
                if (langid == "1")
                {
                    strQuery += " FileTitle as Title, FileDtl as Desc1 ";
                }
                else
                {
                    strQuery += " FileTitle_LL as Title, FileDtl_LL as Desc1 ";
                }
                strQuery += " FROM MOLUPLOADFILE A INNER JOIN MOLFILECATEGORY B ON B.FILETYPEVALUE=A.CATEGORY AND B.LANGID=A.LANGID ";
                strQuery += " WHERE B.FILETYPEVALUE=14 And A.ApprovalStatus=1 order by Rowid desc";
                cmdBanner.CommandText = strQuery;
                DataTable dtWhatsNew = new DataTable();
                dtWhatsNew = MAHAITDBAccess.ExecuteDataSet(cmdBanner).Tables[0];
                if (dtWhatsNew != null)
                {
                    //sb.Append("<ul>");
                    if (dtWhatsNew.Rows.Count > 0)
                    {
                        RptrWhatsNew.DataSource = dtWhatsNew;
                        RptrWhatsNew.DataBind();
                    }

                }
            }
        }

        protected void RptrWhatsNew_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
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
                        Response.AddHeader("Content-Disposition", "attachment;");

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
    }
}