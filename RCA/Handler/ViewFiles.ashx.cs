using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using BL;

namespace RCA.Handler
{
    /// <summary>
    /// Summary description for ViewFiles
    /// </summary>
    public class ViewFiles : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            DataTable dtDownload = new DataTable();
            SqlCommand cmdDownload = new SqlCommand();
            cmdDownload.CommandText = "Select * from News where ID=@ID";
            cmdDownload.Parameters.Add("@ID", SqlDbType.Int);
            cmdDownload.Parameters["@ID"].Value = context.Request.QueryString["ID"]; 
            dtDownload = MAHAITDBAccess.ExecuteDataSet(cmdDownload).Tables[0];
            if (dtDownload != null)
            {
                if (dtDownload.Rows.Count == 1)
                {
                    string Url = dtDownload.Rows[0]["Url"].ToString();                    
                    context.Response.Redirect(Url);                  
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}