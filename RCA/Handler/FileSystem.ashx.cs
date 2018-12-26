using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using BL;

namespace RCA.Handler
{
    /// <summary>
    /// Summary description for FileSystem
    /// </summary>
    public class FileSystem : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            DataTable dtDownload = new DataTable();
            SqlCommand cmdDownload = new SqlCommand();
            cmdDownload.CommandText = "Select * from MOLUploadFile where RowID=@RowID";
            cmdDownload.Parameters.Add("@RowID", SqlDbType.Int);
            cmdDownload.Parameters["@RowID"].Value = context.Request.QueryString["ID"];
            dtDownload = MAHAITDBAccess.ExecuteDataSet(cmdDownload).Tables[0];
            if (dtDownload != null)
            {
                if (dtDownload.Rows.Count == 1)
                {
                    try
                    {
                        string FileType = dtDownload.Rows[0]["FileType"].ToString();
                        string Url = dtDownload.Rows[0]["Url"].ToString();

                        if (!string.IsNullOrEmpty(dtDownload.Rows[0]["FileContent"].ToString()))
                        {

                            context.Response.Buffer = false;
                            context.Response.ClearContent();
                            context.Response.ClearHeaders();
                            context.Response.ContentType = dtDownload.Rows[0]["FileType"].ToString();


                            if (FileType == "application/pdf")
                            {
                                byte[] binary = (dtDownload.Rows[0]["FileContent"]) as byte[];
                                if (binary != null)
                                {
                                    //context.Response.ContentType = "application/pdf";
                                    //context.Response.AddHeader("content-length", binary.Length.ToString());
                                    //context.Response.BinaryWrite(binary);

                                    byte[] pict = (dtDownload.Rows[0]["FileContent"]) as byte[];

                                    string fname = context.Server.MapPath("../Images/Handler/PDF_FileSystem.jpg");

                                    MemoryStream ms = new MemoryStream(FileToByteArray(fname));
                                    Image returnImage = Image.FromStream(ms);

                                    returnImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

                                }
                            }
                            if (FileType == "image/jpeg")
                            {

                                byte[] pict = (dtDownload.Rows[0]["FileContent"]) as byte[];

                                MemoryStream ms = new MemoryStream(pict);
                                Image returnImage = Image.FromStream(ms);

                                returnImage.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }

                        }
                        if (FileType == "Url")
                        {
                            context.Response.Redirect(Url);

                        }

                    }
                    catch (Exception ex)
                    {
                    }

                }
            }


           
        }

        public byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _Buffer;
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