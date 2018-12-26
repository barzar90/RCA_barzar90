using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using BL;

namespace RCA.Controls.WebSiteControls
{
    public partial class InstructionControl : System.Web.UI.UserControl
    {
        BL.BL MAHAITDBAccess;
        private Boolean _ShowMoreNewsOnNewsItem;

        public Boolean ShowMoreNewsOnNewsItem
        {
            get { return _ShowMoreNewsOnNewsItem; }
            set { _ShowMoreNewsOnNewsItem = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetInstruction();

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            lblInstructionMore.Text = _MahaITUC.GetResourceValue("General", "lblInstructionMore", "");

        }

        private void GetInstruction()
        {
            try
            {
                SqlCommand cmdBanner = new SqlCommand();
                cmdBanner.CommandType = CommandType.Text;

                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
                {
                    MAHAITDBAccess.LangID = "2";
                }
                else
                {
                    MAHAITDBAccess.LangID = "1";
                }
                string langid = MAHAITDBAccess.LangID.ToString();

                string strQuery;
                string NewsCount = System.Configuration.ConfigurationManager.AppSettings["NewsCount"].ToString();
               
                StringBuilder var1 = new StringBuilder();


                string _Instruction = langid == "1" ? "Instruction" : "Instruction_LL";

                var1.Append("SELECT TOP " + NewsCount + " ( CASE \n");
                var1.Append("WHEN Len(" + _Instruction + ") > 55 THEN \n");
                var1.Append("CASE \n");
                var1.Append("WHEN Charindex(' ', " + _Instruction + ", 55) = 0 THEN \n");
                var1.Append("'<lable>' + CONVERT(VARCHAR(11), createddate, 106) + '</lable>' \n");
                var1.Append("+ '' + " + _Instruction + " \n");
                var1.Append("ELSE \n");
                var1.Append("CASE \n");
                var1.Append("WHEN isnew = 1 THEN '<lable>'+ Substring(CONVERT(VARCHAR(11), createddate, 106) \n + '</lable>' +" + _Instruction + ", 0, Charindex(' ', \n");
                var1.Append("CONVERT( \n");
                var1.Append("VARCHAR( \n");
                var1.Append("11), \n");
                var1.Append("createddate, 106) + \n");
                var1.Append("''+ " + _Instruction + ", 55)) \n");
                var1.Append("+ '...' \n");
                var1.Append("+ \n");
                var1.Append("'<img src=" + '"' + "../../img/gif_new.gif" + '"' + " class=" + '"' + "new" + '"' + " alt=" + '"' + " News" + '"' + "/>' \n");
                var1.Append("ELSE '<lable>' + Substring(CONVERT(VARCHAR(11), createddate, 106) \n + '</lable>' +" + _Instruction + ", 0, Charindex(' ', " + _Instruction + ", 55)) \n");
                var1.Append("+ '...' \n");
                var1.Append("END \n");
                var1.Append("END \n");
                var1.Append("ELSE \n");
                var1.Append("CASE \n");
                var1.Append("WHEN isnew = 1 THEN '<lable>' + CONVERT(VARCHAR(11), createddate, 106) + '</lable>' \n");
                var1.Append("+ '<br/>' + " + _Instruction + " \n");
                var1.Append("+ \n");
                var1.Append("'<img src=" + '"' + "../../img/gif_new.gif" + '"' + " class=" + '"' + "new" + '"' + " alt=" + '"' + " News" + '"' + "/>' \n");
                var1.Append("ELSE '<lable>' + CONVERT(VARCHAR(11), createddate, 106) + '</lable>' \n");
                var1.Append("+ '' + " + _Instruction + " \n");
                var1.Append("END \n");
                var1.Append("END ) AS Instruction, \n");
                var1.Append("* \n");
                var1.Append("FROM   Instructions \n");
                var1.Append("Where Is_Active = 1 \n");
                var1.Append("ORDER  BY CreatedDate DESC,ID DESC ");

                strQuery = var1.ToString();
                cmdBanner.CommandText = strQuery;
                DataTable dtWhatsNew = new DataTable();
                dtWhatsNew = MAHAITDBAccess.ExecuteDataSet(cmdBanner).Tables[0];
                if (dtWhatsNew != null)
                {
                    if (dtWhatsNew.Rows.Count > 0)
                    {
                        RptrInstruction.DataSource = dtWhatsNew;
                        RptrInstruction.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {


            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void RptrInstruction_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

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