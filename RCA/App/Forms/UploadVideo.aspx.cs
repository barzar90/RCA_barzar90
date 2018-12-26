using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;
using Helper;

namespace RCA.App.Forms
{
    public partial class UploadVideo : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private bool isValidAttachmentFile_Audio(FileUpload FileUploader)
        {
            bool isValid = false;


            if ((FileUploader.HasFile))
            {
                if (CommonFuntion.check_Extensions(FileUploader.FileName))
                {
                    Stream fs = null;
                    fs = FileUploader.PostedFile.InputStream;

                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);

                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File is in wrong format,It should be .mp3 Formatted .');", true);
            }
            }

            return isValid;
        }
        private bool isValidAttachmentFile_Video(FileUpload FileUploader)
        {
            bool isValid = false;


            if ((FileUploader.HasFile))
            {
                if (CommonFuntion.check_Extensions(FileUploader.FileName))
                {
                    Stream fs = null;
                    fs = FileUploader.PostedFile.InputStream;

                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);


                    if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, FileUploader.PostedFile.ContentType))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;

                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File Is InValid , Kindly Upload avi/mpg/mpg/flv/wmv/mp4 Formatted file.');", true);

                    }
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Image file is in wrong format,It should be .avi/.mpg/.mpg/.flv/.wmv/.mp4 Formatted .');", true);
                    //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Image file is in wrong format,It should be jpg/jpeg/bmp/gif/png Formatted .');", true);
                }
            }

            return isValid;
        }
        private bool isValidAttachmentFile(FileUpload FileUploader)
        {
            if (ddlSelectMEdiaType.SelectedItem.Text.ToLower() == "audio")
            {

                if (isValidAttachmentFile_Audio(FileUpload2))
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (ddlSelectMEdiaType.SelectedItem.Text.ToLower() == "video")
            {

                if (isValidAttachmentFile_Video(FileUpload1))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        private bool isValidAttachmentFileUpdate(FileUpload FileUploader, HiddenField mediatype)
        {
            if (mediatype.Value.ToLower() == "audio")
            {

                if (isValidAttachmentFile_Audio(FileUploader))
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (mediatype.Value.ToLower() == "video")
            {

                if (isValidAttachmentFile_Video(FileUploader))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        private Boolean validatedata()
        {
            ltrmsg.Text = string.Empty;
            Boolean isvalid = true;

            StringBuilder sb = new StringBuilder();

            try
            {

                if (ddlSelectMEdiaType.SelectedIndex.ToString() == "0")
                {
                    sb.Append("<span style='color:red'><li>Please select Media Type</li></span>");
                }

                if (ddlSelectMEdiaType.SelectedIndex.ToString() == "1" && (FileUpload2.FileName == string.Empty || FileUpload2.FileName == null))
                {
                    sb.Append("<span style='color:red'><li>Please Upload Audio File To Be Upload</li></span>");
                }

                if (ddlSelectMEdiaType.SelectedIndex.ToString() == "2" && (FileUpload1.FileName == string.Empty || FileUpload1.FileName == null))
                {
                    sb.Append("<span style='color:red'><li>Please Upload Vedio File To Be Upload</li></span>");
                }

                if (txtvideoname.Text == string.Empty || txtvideoname.Text == null)
                {
                    sb.Append("<span style='color:red'><li>Please Enter Video/Audio Name</li></span>");
                }

                if (txtvideoname_LL.Text == string.Empty || txtvideoname_LL.Text == null)
                {
                    sb.Append("<span style='color:red'><li>Please Enter Video/Audio Name In Marathi</li></span>");
                }

                if (sb.Length > 0)
                {
                    ltrmsg.Text = "<span style='color:red'><ul><li>Error List :</li>" + sb.ToString() + "</ul></span>";
                    isvalid = false;
                }

                return isvalid;
            }


            finally
            { sb = null; }
        }



        protected void btnInvoke_Click(object sender, EventArgs e)
        {
              try
            {
                if (validatedata() == true)
                {

                    string loc, MBSize;
                    Stream fs = null;
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    DateTime dt = DateTime.Now;
                    string tme = dt.ToLongTimeString();
                    string[] t = tme.Split(':');

                    string hardcode = "../../Site/Upload/Video/";

                    string y = "";
                    SqlCommand sqlcomm = new SqlCommand();
                    sqlcomm.CommandType = CommandType.StoredProcedure;
                    sqlcomm.CommandText = "videos_upload";
                    sqlcomm.CommandTimeout = 30;

                    if (ddlSelectMEdiaType.SelectedValue == "2")
                    {
                        if (isValidAttachmentFile(FileUpload1))
                        {

                            fs = FileUpload1.PostedFile.InputStream;
                            BinaryReader br1 = new BinaryReader(fs);
                            string name = FileUpload1.PostedFile.FileName;
                            byte[] bytfile = FileUpload1.FileBytes;
                            string strFileName = FileUpload1.FileName;

                            foreach (string x in t)
                            {
                                y += x;
                            }

                            string aa = y + "_" + name;

                            FileUpload1.SaveAs(Server.MapPath("~/Site/Upload/Video//") + aa);
                            loc = aa;
                            MBSize = (FileUpload1.PostedFile.ContentLength / 1048576.00).ToString("f2");
                            string filepath = hardcode + loc;
                            sqlcomm.Parameters.Add("@video_loc", SqlDbType.VarChar, 1000).Value = loc;
                            sqlcomm.Parameters.Add("@Size", SqlDbType.VarChar, 2000).Value = MBSize;
                            sqlcomm.Parameters.Add("@Path", SqlDbType.NVarChar, 300).Value = filepath;
                        }
                    }
                    else if (ddlSelectMEdiaType.SelectedValue == "1")
                    {
                          string videopath = Server.MapPath("~/Site/Upload/Video/");

                         if (FileUpload2.HasFile)
                            {
                               string fileextension = System.IO.Path.GetExtension(FileUpload2.FileName);
                              if (fileextension.ToUpper() != ".MP3")
                              {
                                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('Invalid Audio File');", true);
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Invalid Audio File');", true);

                                FileUpload2.Focus();
                                return;
                              }
                                    FileUpload2.PostedFile.SaveAs(videopath + FileUpload2.FileName);
                              ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Upload File Successfully');", true);
                         }



                            sqlcomm.Parameters.Add("@video_loc",DBNull.Value);
                            sqlcomm.Parameters.Add("@Size",DBNull.Value);
                            sqlcomm.Parameters.Add("@Path", SqlDbType.NVarChar, 300).Value = videopath;// FileUpload2.FileName;
                        }

                    
                    sqlcomm.Parameters.Add("@video_name", SqlDbType.VarChar, 1000).Value = txtvideoname.Text;
                    sqlcomm.Parameters.Add("@video_name_LL", SqlDbType.NVarChar, 2000).Value = txtvideoname.Text;
                    sqlcomm.Parameters.Add("@MediaType", SqlDbType.VarChar, 2000).Value = ddlSelectMEdiaType.SelectedItem.Text.ToString();

                    int res = MAHAITDBAccess.ExecuteNonQuery(sqlcomm);

                    if (res > 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Media uploaded successfully')", true);
                        txtvideoname.Text = "";
                        txtvideoname_LL.Text = "";
                        ddlSelectMEdiaType.SelectedIndex = 0;
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Try .Wmv Format Only')", true);
                    }

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {

            }
        
        }

        protected void ddlSelectMEdiaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSelectMEdiaType.SelectedValue == "1")
            {
                trAudio.Visible = true;
                trVideo.Visible = false;
            }
            else if (ddlSelectMEdiaType.SelectedValue == "2")
            {
                trAudio.Visible = false;
                trVideo.Visible = true;
            }
        }
    }
}