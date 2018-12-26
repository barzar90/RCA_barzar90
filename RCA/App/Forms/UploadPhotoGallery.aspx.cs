using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Helper;
using System.Runtime.InteropServices;  


namespace RCA.FORMS
{
    public partial class UploadPhotoGallery : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListViewBind();
            }
        }

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
        [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
        System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
        System.UInt32 dwMimeFlags,
        out System.UInt32 ppwzMimeOut,
        System.UInt32 dwReserverd);  
        public void ListViewBind()
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from GalleryImage order by ID desc";
            cmd1.CommandTimeout = 30;

            DataSet ds1 = new DataSet();
            ds1 = MAHAITDBAccess.ExecuteDataSet(cmd1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                LV.DataSource = ds1;
                LV.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && txtTitle.Text!="")
            {
                //original image upload
                try
                {
                    if (isValidAttachmentFile(FileUpload1))
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into GalleryImage(title,path) values(@title,@path)";
                        cmd1.CommandTimeout = 30;
                        cmd1.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd1.Parameters.AddWithValue("@path", FileUpload1.FileName);
                        // DataSet ds1 = new DataSet();
                        int count = MAHAITDBAccess.ExecuteNonQuery(cmd1);
                        ListViewBind();
                        if (count > 0)
                        {
                            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                            FileUpload1.SaveAs(Server.MapPath("~/Site/Upload/galleryImages//") + FileUpload1.FileName);

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo saved successfully');", true);
                            return;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File Not Saved');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Invalid File !!!!!');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('" + ex.Message + "');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select multimedia file!');", true);
                return;
            }
        }

        protected void LV_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            LV.EditIndex = e.NewEditIndex;
            ListViewBind();
        }
       
        protected void LV_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
           
            try
            {
                ListViewDataItem item = LV.Items[e.ItemIndex];
                string uid = (LV.DataKeys[e.ItemIndex].Value.ToString());
                TextBox title = (TextBox)item.FindControl("txtTitle");
                FileUpload path = (FileUpload)item.FindControl("EditFileUpload");

               
                string _imgPath = path.FileName;
                if (_imgPath == string.Empty)
                {
                    MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "Update GalleryImage set Title=@Title  where ID=@ID";
                    cmd1.CommandTimeout = 30;
                    cmd1.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd1.Parameters.AddWithValue("@ID", uid);
                    // DataSet ds1 = new DataSet();
                    MAHAITDBAccess.ExecuteNonQuery(cmd1);
                    LV.EditIndex = -1;
                    ListViewBind();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Updated successfully');", true);

                }
                else
                {
                    if (isValidAttachmentFile(path))
                    {
                        // path.SaveAs(Server.MapPath("~/SITE/Graphics/Images/photoGallery//") + _imgPath);
                        path.SaveAs(Server.MapPath("~/Site/Upload/galleryImages//") + _imgPath);

                        MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "Update GalleryImage set Title=@Title,Path=@Path  where ID=@ID";
                        cmd1.CommandTimeout = 30;
                        cmd1.Parameters.AddWithValue("@Title", txtTitle.Text);
                        cmd1.Parameters.AddWithValue("@Path", _imgPath);
                        cmd1.Parameters.AddWithValue("@ID", uid);
                        MAHAITDBAccess.ExecuteNonQuery(cmd1);
                        LV.EditIndex = -1;
                        ListViewBind();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Photo Updated successfully');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Invalid File!!');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { MAHAITDBAccess = null; }
        }


        protected void LV_ItemCanceling1(object sender, ListViewCancelEventArgs e)
        {
            LV.EditIndex = -1;
            ListViewBind();
        }

        protected void LV_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            try
            {
                string uid1 = (LV.DataKeys[e.ItemIndex].Value.ToString());
                MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "delete from GalleryImage where ID = @ID";
                cmd1.CommandTimeout = 30;

                cmd1.Parameters.AddWithValue("@ID", uid1);
                // DataSet ds1 = new DataSet();
                MAHAITDBAccess.ExecuteNonQuery(cmd1);
                LV.EditIndex = -1;
                ListViewBind();
            }
            catch (Exception ex)
            {
            }

            finally { MAHAITDBAccess = null; }
        }

        protected void LV_ItemEditing1(object sender, ListViewEditEventArgs e)
        {
            LV.EditIndex = e.NewEditIndex;
            ListViewBind();
        }

        protected void LV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LV_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx", true);
        }

        private bool isValidAttachmentFile(FileUpload FileUploader)
        {
            bool isValid = false;
            HttpPostedFile file = FileUploader.PostedFile;
            byte[] document = new byte[file.ContentLength];
            file.InputStream.Read(document, 0, file.ContentLength);
            System.UInt32 mimetype;
            FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
            System.IntPtr mimeTypePtr = new IntPtr(mimetype);
            string mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            if (mime == "image/jpeg" || mime == "image/bmp" || mime == "image/gif" || mime == "image/png")
            {
                if ((FileUploader.HasFile))
                {
                    if (CommonFuntion.check_Extensions(FileUploader.FileName))
                    {
                        Stream fs = null;
                        fs = FileUploader.PostedFile.InputStream;

                        BinaryReader br1 = new BinaryReader(fs);
                        byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);

                        if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                        {
                            String ext = FileUploader.FileName;
                            String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                            if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                            { isValid = true; }
                            else { isValid = false; }
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Image file is in wrong format.');", true);
                    }
                }

            }
            return isValid;
        }

    }
}
