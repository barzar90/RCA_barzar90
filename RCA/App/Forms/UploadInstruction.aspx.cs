using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Helper;
using AjaxControlToolkit;

namespace MSHC.App.Forms
{
    public partial class UploadInstruction : System.Web.UI.Page
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        string serverpath = "../../site/Upload/pdf/";
        string sqlQuery;
        Label lbl_ID;
        TextBox txt_Instruction, txt_Instruction_LL;
        Label lbl_Instruction;

        TextBox txt_URL, txt_URLID, txtDate;
        Label lbl_URL;
        CheckBox Chk;
        RequiredFieldValidator reqFildVdtr;
        FileUpload filUplod;
        FileUpload file_Upload_URL, file_Upload_URLID;
        int LangID = 0, retrnVal;
        bool isValid = false;
        int isAdd = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }

            else
            {
                LangID = 1;
            }

            if (!IsPostBack)
            {
                //if (Convert.ToString(Session["UsertypeID"]).ToUpper() != "5D833BCD-8713-4857-A7BB-4D862D27C5C4")
                //{ Response.Redirect("Login.aspx", true); }

                BindGrid();
            }
        }

        public void BindGrid()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    LangID = 2;
                }

                else
                {
                    LangID = 1;
                }


                SqlCommand t_SQLCmd = new SqlCommand();
                t_SQLCmd.CommandType = CommandType.Text;
                t_SQLCmd.CommandText = "select ROW_NUMBER() over(order by ID) as Sr_No,ID,Instruction,Instruction_LL,URL,Is_Active,isnull(IsNew,'') as IsNew, CreatedDate from Instructions order by ID desc";
                t_SQLCmd.Parameters.AddWithValue("@langid", LangID);

                DataSet ds = new DataSet();
                ds = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
                Session["Instruction"] = ds;
                dg_PDF.DataSource = ds;
                dg_PDF.DataBind();
                lbl_Error.Text = "";
            }
            catch (Exception ex) { }
        }

        private void Insert_Update_Dataset(Object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataSet ds = (DataSet)Session["Instruction"];
            DataRow DR = null;

            txt_Instruction = (TextBox)(e.Item.FindControl("txt_Instruction"));
            txt_Instruction_LL = (TextBox)(e.Item.FindControl("txt_Instruction_LL"));
            txt_URL = (TextBox)(e.Item.FindControl("txt_URL"));
            file_Upload_URL = (FileUpload)(e.Item.FindControl("UploadFile"));
            txtDate = (TextBox)(e.Item.FindControl("txt_CreatedDate"));
            DateTime date = Convert.ToDateTime(txtDate.Text);
            if (e.CommandName == "Add")
            {
                try
                {
                    if (Allow_To_Add_Update(1) == true)
                    {
                        SqlCommand t_SQLCmd = new SqlCommand();
                        t_SQLCmd.CommandType = CommandType.Text;
                        t_SQLCmd.CommandText = "Insert into Instructions (Instruction,Instruction_LL,URL,langid,Is_Active,CreatedDate,IsLink) values(@Instruction,@Instruction_LL,@URL,@langid,@Is_Active,@CreatedDate,@IsLink)";

                        t_SQLCmd.Parameters.AddWithValue("@Instruction", txt_Instruction.Text.Trim());
                        t_SQLCmd.Parameters.AddWithValue("@Instruction_LL", txt_Instruction_LL.Text.Trim());
                        t_SQLCmd.Parameters.AddWithValue("@langid", LangID);
                        t_SQLCmd.Parameters.AddWithValue("@Is_Active", '1');
                        //t_SQLCmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        t_SQLCmd.Parameters.AddWithValue("@CreatedDate", date);

                        if (txt_URL.Visible == true)
                        {
                            t_SQLCmd.Parameters.AddWithValue("@IsLink", 1);
                            t_SQLCmd.Parameters.AddWithValue("@URL", txt_URL.Text.Trim());
                            MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully');", true);
                        }
                        else if (file_Upload_URL.Visible == true)
                        {
                            if (file_Upload_URL.HasFile)
                            {
                                t_SQLCmd.Parameters.AddWithValue("@IsLink", 0);
                                if (isValidFile(file_Upload_URL))
                                {
                                    string filename = Path.GetFileName(file_Upload_URL.FileName);
                                    file_Upload_URL.SaveAs(Server.MapPath("../../Site/Upload/Pdf/") + filename);
                                    string path = "../../Site/Upload/Pdf/";
                                    t_SQLCmd.Parameters.AddWithValue("@URL", path + filename);
                                }
                                else
                                    t_SQLCmd.Parameters.AddWithValue("@URL", DBNull.Value);
                            }
                            else
                            {
                                t_SQLCmd.Parameters.AddWithValue("@IsLink", DBNull.Value);
                                t_SQLCmd.Parameters.AddWithValue("@URL", DBNull.Value);
                            }
                                MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully');", true);
                            
                        }
                        else
                        { }

                        BindGrid();
                    }
                }
                catch (Exception ex) { }
            }
            else if (e.CommandName == "Update")
            {
                string HrfUrl = string.Empty;
                string ImageUrl = string.Empty;
                try
                {
                    if (Allow_To_Add_Update(0) == true)
                    {
                        lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));
                        SqlCommand t_SQLCmd = new SqlCommand();
                        t_SQLCmd.CommandType = CommandType.Text;


                        t_SQLCmd.Parameters.AddWithValue("@Instruction", txt_Instruction.Text.Trim());
                        t_SQLCmd.Parameters.AddWithValue("@Instruction_LL", txt_Instruction_LL.Text.Trim());
                        t_SQLCmd.Parameters.AddWithValue("@ID", lbl_ID.Text);
                        t_SQLCmd.Parameters.AddWithValue("@langid", LangID);
                        t_SQLCmd.Parameters.AddWithValue("@CreatedDate", date);
                        if (txt_URL.Visible == true)
                        {
                            t_SQLCmd.Parameters.AddWithValue("@IsLink", 1);
                            t_SQLCmd.Parameters.AddWithValue("@URL", txt_URL.Text.Trim());
                            HrfUrl = "URL=@URL,";

                        }
                        else
                        {
                            t_SQLCmd.Parameters.AddWithValue("@IsLink", 0);
                            if (file_Upload_URL.HasFile)
                            {
                                if (isValidAttachmentFile(file_Upload_URL))
                                {
                                    string filename = Path.GetFileName(file_Upload_URL.FileName);
                                    file_Upload_URL.SaveAs(Server.MapPath("../../Site/Upload/Pdf/") + filename);
                                    string path = "../../Site/Upload/Pdf/";
                                    t_SQLCmd.Parameters.AddWithValue("@URL", path + filename);
                                    HrfUrl = "URL=@URL,";
                                }
                            }
                        }
                        t_SQLCmd.CommandText = "update Instructions set " + HrfUrl + " Instruction =@Instruction, Instruction_LL =@Instruction_LL,IsLink=@IsLink,CreatedDate=@CreatedDate where ID=@ID ";
                        retrnVal = MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd); //t_SQLCmd.ExecuteNonQuery();
                        if (retrnVal.ToString() == "1")
                        { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Updated SucessFully');", true); }
                        else { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Not Updated');", true); }

                        dg_PDF.EditItemIndex = -1;
                        BindGrid();
                    }
                }
                catch (Exception ex) { }
            }
        }

        private bool Allow_To_Add_Update(int isAdd)
        {
            if (txt_Instruction.Text == "")
            {
                lbl_Error.Text = "Please Enter Instruction";
            }
            else
            {
                isValid = true;
                lbl_Error.Text = "";
            }
            return isValid;
        }
        protected void dg_PDF_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dg_PDF.EditItemIndex = -1;
            BindGrid();
        }

        protected void dg_PDF_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));
                // MOLDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                SqlCommand t_SQLCmd = new SqlCommand();
                t_SQLCmd.CommandType = CommandType.Text;
                t_SQLCmd.CommandText = "delete from Instructions where ID=@ID";
                t_SQLCmd.Parameters.AddWithValue("@ID", lbl_ID.Text);
                MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);
                BindGrid();
            }
            catch (Exception ex) { }
        }

        protected void dg_PDF_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dg_PDF.EditItemIndex = e.Item.ItemIndex;
            BindGrid();
        }

        protected void dg_PDF_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Insert_Update_Dataset(source, e);
            }
        }

        protected void dgev_PDF_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DataSet ds = (DataSet)Session["Instruction"];
                DataRow[] DR;

                txt_Instruction = (TextBox)(e.Item.FindControl("txt_Instruction"));
                txt_Instruction_LL = (TextBox)(e.Item.FindControl("txt_Instruction_LL"));
                txt_URL = (TextBox)(e.Item.FindControl("txt_URL"));
                lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));

                DR = ds.Tables[0].Select("ID=" + lbl_ID.Text.Trim());

                txt_Instruction.Text = DR[0]["Instruction"].ToString();
                txt_Instruction_LL.Text = DR[0]["Instruction_LL"].ToString();
                txt_URL.Text = DR[0]["URL"].ToString();
            }
            if (e.Item.ItemIndex >= 0)
            {
                Label lblIsNew = (Label)e.Item.FindControl("lblIsNew");
                CheckBox chknew = (CheckBox)e.Item.FindControl("Chkstatus");
                Label Label1 = (Label)e.Item.FindControl("Label1");

                if (lblIsNew.Text == "False")
                {
                    chknew.Checked = false;
                }
                else
                {
                    chknew.Checked = true;
                }
            }
        }

        protected void chkFt_URL_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            DataGridItem Item = (DataGridItem)chk.Parent.Parent;
            txt_URLID = (TextBox)(Item.FindControl("txt_URL"));
            file_Upload_URLID = (FileUpload)(Item.FindControl("UploadFile"));
            if (chk.Checked == true)
            {
                txt_URLID.Visible = true;
                file_Upload_URLID.Visible = false;
            }
            else
            {
                txt_URLID.Visible = false;
                file_Upload_URLID.Visible = true;
            }
        }

        protected void chkEd_URL_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            DataGridItem Item1 = (DataGridItem)chk.Parent.Parent;
            txt_URLID = (TextBox)(Item1.FindControl("txt_URL"));
            file_Upload_URLID = (FileUpload)(Item1.FindControl("UploadFile"));
            if (chk.Checked == true)
            {
                txt_URLID.Visible = true;
                file_Upload_URLID.Visible = false;
            }
            else
            {
                txt_URLID.Visible = false;
                file_Upload_URLID.Visible = true;
            }
        }
        protected void chkbox_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chknew = (CheckBox)dg_PDF.FindControl("Chkstatus");
            CheckBox chk = (CheckBox)sender;

            //  MOLDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandType = CommandType.Text;
            string key = ((CheckBox)sender).Attributes["key"];
            string update = string.Empty;

            if (chk.Checked == true)
            {
                t_SQLCmd.CommandText = "Update Instructions SET IsNew=@IsNew where ID=@ID ";
                t_SQLCmd.Parameters.AddWithValue("@IsNew", '1');
                t_SQLCmd.Parameters.AddWithValue("@ID", key);
                //update = "Update News SET IsNew='1' where ID='" + key + "'";
            }
            else
            {
                t_SQLCmd.CommandText = "Update Instructions SET IsNew=@IsNew where ID=@ID ";
                t_SQLCmd.Parameters.AddWithValue("@IsNew", '0');
                t_SQLCmd.Parameters.AddWithValue("@ID", key);
                //update = "Update News SET IsNew='0' where ID='" + key + "'";
            }
            MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);

            BindGrid();
        }
        protected void dg_PDF_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            Insert_Update_Dataset(source, e);
        }
        protected void chk_Is_Active_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            DataGridItem Item = (DataGridItem)chk.Parent.Parent;
            lbl_ID = (Label)(Item.FindControl("lbl_ID"));
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandType = CommandType.Text;
            t_SQLCmd.CommandText = "update Instructions set Is_Active =@Is_Active where ID=@ID  and langid=@langid";
            t_SQLCmd.Parameters.AddWithValue("@Is_Active ", chk.Checked);
            t_SQLCmd.Parameters.AddWithValue("@ID", lbl_ID.Text.Trim());
            t_SQLCmd.Parameters.AddWithValue("@langid", LangID);


            MAHAITDBAccess.ExecuteNonQuery(t_SQLCmd);
            //conn.Close();
            dg_PDF.EditItemIndex = -1;
            BindGrid();

            dg_PDF.EditItemIndex = -1;
            BindGrid();
        }
        private bool isValidAttachmentFile(FileUpload FileUploader)
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

                    String ext = FileUploader.FileName;
                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                    if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                    {
                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                            isValid = true;

                    }
                    else if (CommonFuntion.isValidFile(FileUploader.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                    {
                        if (extention.ToLower() == "pdf")
                            isValid = true;
                    }
                    else if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, FileUploader.PostedFile.ContentType))
                    {
                        if (extention.ToLower() == "avi" || extention.ToLower() == "3gp" || extention.ToLower() == "mp4" || extention.ToLower() == "mpg" || extention.ToLower() == "flv" || extention.ToLower() == "wmv")
                            isValid = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('InValid File');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File is InValid');", true);
            }
            return isValid;
        }


        private bool isValidFile(FileUpload FileUploader)
        {
            bool retnVal = false;
            string extEng = Path.GetFileName(FileUploader.FileName).Substring(Path.GetFileName(FileUploader.FileName).IndexOf(".") + 1, 3);
           // string extMar = FileUploader.HasFile ? Path.GetFileName(FileUploader.FileName).Substring(Path.GetFileName(FileUploader.FileName).IndexOf(".") + 1, 3) : extEng;
           // if (CommonFuntion.isValidFile(FileUploader.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                if (FileUploader.HasFile)
                    if (CommonFuntion.isValidFile(FileUploader.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                        if ((extEng.ToLower() == "pdf"))
                            retnVal = true;
                        else
                            retnVal = false;
                    else
                        retnVal = false;
                else
                    retnVal = true;
           // else
            //    retnVal = false;

            return retnVal;
        }
    }
}