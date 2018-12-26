using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using BL;

namespace MSHC.App.STD
{
    /// <summary>
    /// Summary description for GetFile
    /// </summary>
    public class GetFile : IHttpHandler
    {
        BL.BL MAHAITDBAccess;

        public GetFile()
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());      
        }

        public void ProcessRequest(HttpContext context)
        {
            string t_FileID = context.Request.QueryString["ID"].ToString();
            SqlCommand t_SQLCmd = new SqlCommand();
            DataSet t_DS = null;

            t_SQLCmd.CommandText = "Select ImageType,ImageContent From MOLImages where ImageID = @ID";
            t_SQLCmd.Parameters.Add("@ID", System.Data.SqlDbType.VarChar);
            t_SQLCmd.Parameters["@ID"].Value = t_FileID;
            t_DS = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);

            if (t_DS.Tables[0].Rows.Count == 0)
            {
                t_SQLCmd.Parameters["@ID"].Value = "Not Found";
                t_DS = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
            }

            context.Response.ContentType = t_DS.Tables[0].Rows[0]["ImageType"].ToString();

            byte[] pict = (byte[])t_DS.Tables[0].Rows[0]["ImageContent"];

            MemoryStream ms = new MemoryStream(pict);
            Image returnImage = Image.FromStream(ms);

            returnImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);

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